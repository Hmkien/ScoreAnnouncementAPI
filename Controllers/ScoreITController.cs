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
    public class ScoreITController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScoreITController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ScoreIT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreIT>>> GetScoreIT()
        {
            return await _context.ScoreIT.ToListAsync();
        }

        // GET: api/ScoreIT/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreIT>> GetScoreIT(int id)
        {
            var scoreIT = await _context.ScoreIT.FindAsync(id);

            if (scoreIT == null)
            {
                return NotFound();
            }

            return scoreIT;
        }

        // PUT: api/ScoreIT/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScoreIT(int id, ScoreIT scoreIT)
        {
            if (id != scoreIT.ScoreITCode)
            {
                return BadRequest();
            }

            _context.Entry(scoreIT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreITExists(id))
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

        // POST: api/ScoreIT
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScoreIT>> PostScoreIT(ScoreIT scoreIT)
        {
            _context.ScoreIT.Add(scoreIT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScoreIT", new { id = scoreIT.ScoreITCode }, scoreIT);
        }

        // DELETE: api/ScoreIT/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScoreIT(int id)
        {
            var scoreIT = await _context.ScoreIT.FindAsync(id);
            if (scoreIT == null)
            {
                return NotFound();
            }

            _context.ScoreIT.Remove(scoreIT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScoreITExists(int id)
        {
            return _context.ScoreIT.Any(e => e.ScoreITCode == id);
        }
    }
}
