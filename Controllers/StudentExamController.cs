using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreAnnouncementAPI.Data;
using ScoreAnnouncementAPI.Models.Entities;

namespace ScoreAnnouncementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentExamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentExam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentExam>>> GetStudentExam()
        {
            return await _context.StudentExam.ToListAsync();
        }

        // GET: api/StudentExam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentExam>> GetStudentExam(Guid id)
        {
            var studentExam = await _context.StudentExam.FindAsync(id);

            if (studentExam == null)
            {
                return NotFound();
            }

            return studentExam;
        }

        // PUT: api/StudentExam/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentExam(Guid id, StudentExam studentExam)
        {
            if (id != studentExam.StudentExamId)
            {
                return BadRequest();
            }

            _context.Entry(studentExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExamExists(id))
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

        // POST: api/StudentExam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentExam>> PostStudentExam(StudentExam studentExam)
        {
            _context.StudentExam.Add(studentExam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentExam", new { id = studentExam.StudentExamId }, studentExam);
        }

        // DELETE: api/StudentExam/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentExam(Guid id)
        {
            var studentExam = await _context.StudentExam.FindAsync(id);
            if (studentExam == null)
            {
                return NotFound();
            }

            _context.StudentExam.Remove(studentExam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExamExists(Guid id)
        {
            return _context.StudentExam.Any(e => e.StudentExamId == id);
        }
    }
}
