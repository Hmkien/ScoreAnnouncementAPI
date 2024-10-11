using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreAnnouncementAPI.Data;
using ScoreAnnouncementAPI.Models.Entities;
using ScoreAnnouncementAPI.Models.ViewModels;

namespace ScoreAnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(string id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(string id, Student student)
        {
            if (id != student.StudentCode)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Student.Add(student);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StudentCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudent", new { id = student.StudentCode }, student);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.StudentCode == id);
        }
        [HttpGet("Student")]
        public async Task<IActionResult> DisplayStudent(int examId)
        {
            if (examId == null)
                return Ok("Không tìm thấy kì thi,Vui lòng thử lại sau");
            int ExamTypeId = Convert.ToInt32(_context.Exam.Where(e => e.ExamId == examId).Select(e => e.ExamTypeId).FirstOrDefault());
            if (ExamTypeId == 0 || ExamTypeId == 1)
            {
                var Student = (from std in _context.Student
                               join stdExam in _context.StudentExam on std.StudentCode equals stdExam.StudentCode
                               join score in _context.ScoreFL on std.StudentCode equals score.StudentCode
                               select new ForeinLanguage
                               {
                                   StudentCode = std.StudentCode,
                                   LastName = std.LastName,
                                   FirstName = std.FirstName,
                                   SpeakingScore = score.SpeakingScore,
                                   ListeningScore = score.ListeningScore,
                                   WritingScore = score.WritingScore,
                                   ReadingScore = score.ReadingScore,
                                   TotalScore = score.TotalScore,
                                   Result = score.Result,
                                   Note = score.Note,
                                   Course = std.Course,
                                   Faculty = std.Faculty,
                                   Email = std.Email,
                                   PhoneNumber = std.PhoneNumber
                               }).ToList();
                return Ok(Student);

            }
            else if (ExamTypeId == 4)
            {
                var Student = (from std in _context.Student
                               join stdExam in _context.StudentExam on std.StudentCode equals stdExam.StudentCode
                               join score in _context.ScoreIT on std.StudentCode equals score.StudentCode
                               select new CNTT_CB_CDR
                               {
                                   StudentCode = std.StudentCode,
                                   LastName = std.LastName,
                                   FirstName = std.FirstName,
                                   ExcelScore = score.ExcelScore,
                                   WordScore = score.WordScore,
                                   PowerPointScore = score.PowerPointScore,
                                   PracticalScore = score.PracticalScore,
                                   TheoryScore = score.TheoryScore,
                                   TotalScore = score.TotalScore,
                                   Result = score.Result,
                                   Note = score.Note,
                                   Course = std.Course,
                                   Faculty = std.Faculty,
                                   Email = std.Email,
                                   PhoneNumber = std.PhoneNumber
                               }).ToList();
                return Ok(Student);

            }
            else if (ExamTypeId == 2)
            {
                var Student = (from std in _context.ITStudent
                               join score in _context.ScoreIT on std.IdentityNumber equals score.IdentityNumber
                               select new CC_CNTT_CB
                               {
                                   IdentificationCode = score.IdentityNumber,
                                   IdentityNumber = score.IdentityNumber,
                                   LastName = std.LastName,
                                   FirstName = std.FirstName,
                                   BirthDay = std.BirthDay,
                                   Gender = std.Gender,
                                   Address = std.Address,
                                   Email = std.Email,
                                   national = std.national,
                                   ExcelScore = score.ExcelScore,
                                   WordScore = score.WordScore,
                                   PowerPointScore = score.PowerPointScore,
                                   PracticalScore = score.PracticalScore,
                                   TheoryScore = score.TheoryScore,
                                   TotalScore = score.TotalScore,
                                   Result = score.Result,
                                   Note = score.Note,

                               }).ToList();
                return Ok(Student);

            }
            return Ok("Đã xảy ra lỗi");
        }
    }
}
