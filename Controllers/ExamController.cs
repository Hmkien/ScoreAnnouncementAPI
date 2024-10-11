using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ScoreAnnouncementAPI.Data;
using ScoreAnnouncementAPI.Models.Entities;
using ScoreAnnouncementAPI.Models.Process;


namespace ScoreAnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public ExamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Exam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExam()
        {
            return await _context.Exam.Where(e => e.IsDelete == false).ToListAsync();
        }

        // GET: api/Exam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            var exam = await _context.Exam.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // PUT: api/Exam/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
            if (id != exam.ExamId)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Exam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            _context.Exam.Add(exam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExam", new { id = exam.ExamId }, exam);
        }

        // DELETE: api/Exam/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _context.Exam.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            exam.IsDelete = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            try
            {
                var result = await _context.Exam.ToListAsync();
                _context.RemoveRange(result);
                await _context.SaveChangesAsync();
                return Ok("Đã xóa hết bản ghi");
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }




        }
        [HttpDelete("check-exam-code")]
        public async Task<IActionResult> CheckExist(string examCode)
        {
            var result = await _context.Exam.FindAsync(examCode);
            if (result == null)
            {
                return NotFound();
            }
            return Ok("Kì thi đã tồn tại");
        }
        private bool ExamExists(int id)
        {
            return _context.Exam.Any(e => e.ExamId == id);
        }
        [HttpPost("upload/{examId}")]
        public async Task<IActionResult> Upload(int examId, IFormFile file)
        {
            if (file == null || file.Length == 0 || !IsValidExcelFile(file.FileName))
            {
                return BadRequest("File không hợp lệ. Vui lòng tải lên file Excel!");
            }

            var exam = await _context.Exam.FindAsync(examId);
            if (exam == null)
            {
                return NotFound("Kỳ thi không tồn tại!");
            }

            if (exam.Status == "Đã hoàn thành")
            {
                return BadRequest("Kỳ thi đã kết thúc. Vui lòng liên hệ quản trị viên!");
            }

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var tempFilePath = Path.GetTempFileName();
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var result = await ImportDataFromExcel(examId, tempFilePath);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private bool IsValidExcelFile(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLower();
            return extension == ".xlsx" || extension == ".xls";
        }
        private async Task<string> ImportDataFromExcel(int examId, string fileLocation)
        {
            string messageResult = await CheckDataFromExcel(fileLocation, examId);
            if (!string.IsNullOrEmpty(messageResult))
            {
                return "Dữ liệu không hợp lệ, vui lòng kiểm tra các dòng: " + messageResult;
            }

            string examType = await _context.Exam
                .Where(e => e.ExamId == examId)
                .Select(e => e.ExamTypeId)
                .FirstOrDefaultAsync();

            var dataFromExcel = _excelProcess.ExcelToDataTable(fileLocation);
            if (dataFromExcel == null || dataFromExcel.Rows.Count == 0)
            {
                return "Dữ liệu file Excel rỗng hoặc không đọc được!";
            }

            var dataRows = dataFromExcel.AsEnumerable();

            if (examType == "1")
            {
                var existingStudentCodes = await _context.Student
                    .Select(m => m.StudentCode)
                    .ToListAsync();

                try
                {
                    var newStudents = dataRows
                        .Where(row => !existingStudentCodes.Contains(row.Field<string>(1)))
                        .Select(row => new Student
                        {
                            StudentCode = row.Field<string>(1),
                            FirstName = row.Field<string>(3),
                            LastName = row.Field<string>(2),
                            Course = row.Field<string>(11)
                        })
                        .ToList();

                    if (newStudents.Any())
                    {
                        await _context.Student.AddRangeAsync(newStudents);
                    }

                    var scoreFLs = dataRows.Select(row => new ScoreFL
                    {
                        StudentCode = row.Field<string>(1),
                        ListeningScore = row.Field<string>(4),
                        ReadingScore = row.Field<string>(5),
                        WritingScore = row.Field<string>(6),
                        SpeakingScore = row.Field<string>(7),
                        TotalScore = row.Field<string>(8),
                        Result = row.Field<string>(9),
                        Note = row.Field<string>(10),
                        ExamId = examId
                    }).ToList();

                    await _context.ScoreFL.AddRangeAsync(scoreFLs);
                    var exam = _context.Exam.Where(e => e.ExamId == examId).FirstOrDefault();
                    exam.Status = "Đã hoàn thành";
                    await _context.BulkSaveChangesAsync();

                    messageResult = $"Import thành công {dataFromExcel.Rows.Count} sinh viên.";
                }
                catch (Exception ex)
                {
                    messageResult = "Dữ liệu bị lỗi, vui lòng kiểm tra lại dữ liệu file Excel! " + ex.Message;
                }
            }
            else if (examType == "0")
            {
                var existingStudentCodes = await _context.Student
                    .Select(m => m.StudentCode)
                    .ToListAsync();

                try
                {
                    if (dataFromExcel.Columns.Count > 11 || dataFromExcel.Columns.Count < 10)
                    {
                        return "File upload không đúng, vui lòng kiểm tra lại!";
                    }

                    var newStudents = dataRows
                        .Where(row => !existingStudentCodes.Contains(row.Field<string>(1)))
                        .Select(row => new Student
                        {
                            StudentCode = row.Field<string>(1),
                            FirstName = row.Field<string>(3),
                            LastName = row.Field<string>(2),
                        })
                        .ToList();

                    if (newStudents.Any())
                    {
                        await _context.Student.AddRangeAsync(newStudents);
                    }

                    var studentExam = dataRows.Select(row => new StudentExam
                    {
                        StudentCode = row.Field<string>(1),
                        ExamId = examId
                    }).ToList();
                    await _context.StudentExam.AddRangeAsync(studentExam);

                    var scoreFLs = dataRows.Select(row => new ScoreFL
                    {
                        StudentCode = row.Field<string>(1),
                        ListeningScore = row.Field<string>(4),
                        ReadingScore = row.Field<string>(5),
                        WritingScore = row.Field<string>(6),
                        SpeakingScore = row.Field<string>(7),
                        TotalScore = row.Field<string>(8),
                        Result = row.Field<string>(9),
                        Note = row.Field<string>(10),
                        ExamId = examId
                    }).ToList();

                    await _context.ScoreFL.AddRangeAsync(scoreFLs);

                    var exam = await _context.Exam.FirstOrDefaultAsync(e => e.ExamId == examId);
                    if (exam != null)
                    {
                        exam.Status = "Đã hoàn thành";
                    }

                    await _context.BulkSaveChangesAsync();

                    messageResult = $"Import thành công {dataFromExcel.Rows.Count} sinh viên.";
                }
                catch (Exception ex)
                {
                    messageResult = "Dữ liệu bị lỗi, vui lòng kiểm tra lại dữ liệu file Excel! " + ex.Message;
                }
            }
            else if (examType == "4")
            {
                var existingStudentCodes = await _context.Student
                      .Select(m => m.StudentCode)
                      .ToListAsync();

                try
                {
                    var newStudents = dataRows
                        .Where(row => !existingStudentCodes.Contains(row.Field<string>(1)))
                        .Select(row => new Student
                        {
                            StudentCode = row.Field<string>(1),
                            FirstName = row.Field<string>(3),
                            LastName = row.Field<string>(2),
                        })
                        .ToList();

                    if (newStudents.Any())
                    {
                        await _context.Student.AddRangeAsync(newStudents);
                    }
                    var StudentExam = dataRows.Select(row => new StudentExam
                    {
                        StudentCode = row.Field<string>(1),
                        ExamId = examId
                    }).ToList();
                    await _context.StudentExam.AddRangeAsync(StudentExam);
                    var scoreITs = dataRows.Select(row => new ScoreIT
                    {
                        StudentCode = row.Field<string>(1),
                        PracticalScore = row.Field<string>(5),
                        TheoryScore = row.Field<string>(4),
                        TotalScore = row.Field<string>(6),
                        Result = row.Field<string>(7),
                        Note = row.Field<string>(8),
                        examId = examId
                    }).ToList();
                    await _context.ScoreIT.AddRangeAsync(scoreITs);
                    var exam = _context.Exam.Where(e => e.ExamId == examId).FirstOrDefault();
                    exam.Status = "Đã kết thúc";
                    await _context.BulkSaveChangesAsync();
                    messageResult = $"Import thành công {dataFromExcel.Rows.Count} sinh viên.";
                }
                catch (Exception ex)
                {
                    messageResult = "Dữ liệu bị lỗi, vui lòng kiểm tra lại dữ liệu file excel! " + ex.Message;
                }
            }

            else if (examType == "2")

            {

                var existingStudentCodes = await _context.ITStudent
                     .Select(m => m.IdentityNumber)
                     .ToListAsync();

                try
                {
                    var newITStudents = dataRows
                        .Where(row => !existingStudentCodes.Contains(row.Field<string>(2)))
                        .Select(row => new ITStudent
                        {
                            IdentificationCode = row.Field<string>(1),
                            IdentityNumber = row.Field<string>(2),
                            LastName = row.Field<string>(3),
                            FirstName = row.Field<string>(4),
                            BirthDay = row.Field<string>(5),
                            Gender = row.Field<string>(6),
                            national = row.Field<string>(7),
                            Address = row.Field<string>(8),
                            ExamId = examId

                        })
                        .ToList();

                    if (newITStudents.Any())
                    {
                        await _context.ITStudent.AddRangeAsync(newITStudents);
                    }
                    var StudentExam = dataRows.Select(row => new StudentExam
                    {
                        IdentityNumber = row.Field<string>(2),
                        ExamId = examId
                    }).ToList();
                    await _context.StudentExam.AddRangeAsync(StudentExam);
                    var scoreITs = dataRows.Select(row => new ScoreIT
                    {
                        IdentityNumber = row.Field<string>(2),
                        TheoryScore = row.Field<string>(9),
                        PracticalScore = row.Field<string>(10),
                        Result = row.Field<string>(11),
                        Note = row.Field<string>(12),
                        examId = examId
                    }).ToList();

                    await _context.ScoreIT.AddRangeAsync(scoreITs);
                    var exam = _context.Exam.Where(e => e.ExamId == examId).FirstOrDefault();
                    exam.Status = "Đã hoàn thành";
                    await _context.BulkSaveChangesAsync();

                    messageResult = $"Import thành công {dataFromExcel.Rows.Count} sinh viên.";
                }
                catch (Exception ex)
                {
                    messageResult = "Dữ liệu bị lỗi, vui lòng kiểm tra lại dữ liệu file excel! " + ex.Message;
                }
            }

            else
            {
                messageResult = "Dữ liệu không hợp lệ, vui lòng kiểm tra các dòng!";
            }

            return messageResult;
        }
        private async Task<string> CheckDataFromExcel(string fileLocation, int examid)
        {
            List<int> errorLines = new List<int>();
            int examType = Convert.ToInt32(await _context.Exam
                .Where(e => e.ExamId == examid)
                .Select(e => e.ExamTypeId)
                .FirstOrDefaultAsync());

            var dataFromExcel = _excelProcess.ExcelToDataTable(fileLocation);

            for (int i = 0; i < dataFromExcel.Rows.Count; i++)
            {
                bool hasError = false;

                if (examType == 0)
                {
                    if (dataFromExcel.Rows[i][1].ToString().Length != 10 ||
                        dataFromExcel.Rows[i][3].ToString().Length > 7 ||
                        !IsValidScore(dataFromExcel.Rows[i][4], 0, 30) ||
                        !IsValidScore(dataFromExcel.Rows[i][5], 0, 30) ||
                        !IsValidScore(dataFromExcel.Rows[i][6], 0, 30) ||
                        !IsValidScore(dataFromExcel.Rows[i][7], 0, 30) ||
                        !IsValidScore(dataFromExcel.Rows[i][8], 0, 120))
                    {
                        hasError = true;
                    }
                }
                else if (examType == 1)
                {
                    if (dataFromExcel.Rows[i][1].ToString().Length != 10 ||
                        dataFromExcel.Rows[i][3].ToString().Length > 7 ||
                        dataFromExcel.Rows[i][11].ToString().Length > 4 ||
                        !IsValidScore(dataFromExcel.Rows[i][4], 0, 30) ||
                        !IsValidScore(dataFromExcel.Rows[i][5], 0, 30) ||
                        !IsValidScore(dataFromExcel.Rows[i][6], 0, 30) ||
                        !IsValidScore(dataFromExcel.Rows[i][7], 0, 30) ||
                        !IsValidScore(dataFromExcel.Rows[i][8], 0, 120))
                    {
                        hasError = true;
                    }
                }
                else if (examType == 2)
                {
                    if (dataFromExcel.Rows[i][2].ToString().Length != 12 ||
                        dataFromExcel.Rows[i][4].ToString().Length > 7)
                    {
                        hasError = true;
                    }

                    if (dataFromExcel.Rows[i][9].ToString().Length != 1 &&
                        !IsValidScore(dataFromExcel.Rows[i][9], 0, 50))
                    {
                        hasError = true;
                    }

                    if (dataFromExcel.Rows[i][10].ToString().Length != 1 &&
                        !IsValidScore(dataFromExcel.Rows[i][10], 0, 50))
                    {
                        hasError = true;
                    }
                }

                else if (examType == 4)
                {
                    if (dataFromExcel.Rows[i][1].ToString().Length != 10 ||
                        dataFromExcel.Rows[i][3].ToString().Length > 7 ||
                        !IsValidScore(dataFromExcel.Rows[i][4], 0, 50) ||
                        !IsValidScore(dataFromExcel.Rows[i][5], 0, 50) ||
                        !IsValidScore(dataFromExcel.Rows[i][6], 0, 100))
                    {
                        hasError = true;
                    }
                }

                if (hasError)
                {
                    errorLines.Add(i + 1);
                }

            }

            return errorLines.Count > 0
                ? "Dữ liệu không hợp lệ, vui lòng kiểm tra các dòng: " + string.Join(", ", errorLines)
                : string.Empty;
        }
        private bool IsValidScore(object scoreObj, double min, double max)
        {
            return double.TryParse(scoreObj.ToString(), out double score) && score >= min && score <= max;
        }


    }
}
