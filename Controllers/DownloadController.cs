using Microsoft.AspNetCore.Mvc;
using ScoreAnnouncementAPI.Data;
using System.IO;
using System.Linq;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDownloadController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FileDownloadController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DownloadFile(int examId)
        {
            var exam = _context.Exam.FirstOrDefault(e => e.ExamId == examId);
            if (exam == null)
            {
                return NotFound("Kỳ thi không tồn tại.");
            }

            string examTypeId = exam.ExamTypeId;

            string filePath;
            string fileName;

            switch (examTypeId)
            {
                case "0":
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Model", "File", "CDR_NN.xlsx");
                    fileName = "CDR_NN.xlsx";
                    break;
                case "1":
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Model", "File", "KiemTra_TrinhDo_NN.xlsx");
                    fileName = "KiemTra_TrinhDo_NN.xlsx";
                    break;
                case "2":
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Model", "File", "CCCNTT-CB.xlsx");
                    fileName = "CCCNTT-CB.xlsx";
                    break;
                case "4":
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "Model", "File", "CDR-CNTCB.xlsx");
                    fileName = "CDR-CNTCB.xlsx";
                    break;
                default:
                    return BadRequest("Loại kỳ thi không xác định.");
            }

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File không tồn tại.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
