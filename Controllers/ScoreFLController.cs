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
    public class ScoreFLController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScoreFLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ScoreFL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScoreFL>>> GetScoreFL()
        {
            return await _context.ScoreFL.ToListAsync();
        }

        // GET: api/ScoreFL/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScoreFL>> GetScoreFL(int id)
        {
            var scoreFL = await _context.ScoreFL.FindAsync(id);

            if (scoreFL == null)
            {
                return NotFound();
            }

            return scoreFL;
        }

        // PUT: api/ScoreFL/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScoreFL(int id, ScoreFL scoreFL)
        {
            if (id != scoreFL.ScoreFLCode)
            {
                return BadRequest();
            }

            _context.Entry(scoreFL).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreFLExists(id))
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

        // POST: api/ScoreFL
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScoreFL>> PostScoreFL(ScoreFL scoreFL)
        {
            _context.ScoreFL.Add(scoreFL);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScoreFL", new { id = scoreFL.ScoreFLCode }, scoreFL);
        }

        // DELETE: api/ScoreFL/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScoreFL(int id)
        {
            var scoreFL = await _context.ScoreFL.FindAsync(id);
            if (scoreFL == null)
            {
                return NotFound();
            }

            _context.ScoreFL.Remove(scoreFL);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScoreFLExists(int id)
        {
            return _context.ScoreFL.Any(e => e.ScoreFLCode == id);
        }
    }
}
