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
    public class ExamTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamType>>> GetExamType()
        {
            return await _context.ExamType.ToListAsync();
        }

        // GET: api/ExamType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamType>> GetExamType(string id)
        {
            var examType = await _context.ExamType.FindAsync(id);

            if (examType == null)
            {
                return NotFound();
            }

            return examType;
        }

        // PUT: api/ExamType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamType(string id, ExamType examType)
        {
            if (id != examType.ExamTypeId)
            {
                return BadRequest();
            }

            _context.Entry(examType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamTypeExists(id))
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

        // POST: api/ExamType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamType>> PostExamType(ExamType examType)
        {
            _context.ExamType.Add(examType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExamTypeExists(examType.ExamTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExamType", new { id = examType.ExamTypeId }, examType);
        }

        // DELETE: api/ExamType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamType(string id)
        {
            var examType = await _context.ExamType.FindAsync(id);
            if (examType == null)
            {
                return NotFound();
            }

            _context.ExamType.Remove(examType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamTypeExists(string id)
        {
            return _context.ExamType.Any(e => e.ExamTypeId == id);
        }
    }
}
