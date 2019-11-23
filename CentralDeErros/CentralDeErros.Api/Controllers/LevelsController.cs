using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ErrorDbContext _context;

        public LevelsController(ErrorDbContext context)
        {
            _context = context;
        }

        // GET: api/Levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Level>>> GetLevels()
        {
            return await _context.Levels.ToListAsync();
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Level>> GetLevel(int id)
        {
            var level = await _context.Levels.FindAsync(id);

            if (level == null)
            {
                return NotFound();
            }

            return level;
        }

        // PUT: api/Levels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevel(int id, Level level)
        {
            if (id != level.LevelId)
            {
                return BadRequest();
            }

            _context.Entry(level).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
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

        // POST: api/Levels
        [HttpPost]
        public async Task<ActionResult<Level>> PostLevel(Level level)
        {
            _context.Levels.Add(level);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevel", new { id = level.LevelId }, level);
        }

        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Level>> DeleteLevel(int id)
        {
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
            {
                return NotFound();
            }

            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();

            return level;
        }

        private bool LevelExists(int id)
        {
            return _context.Levels.Any(e => e.LevelId == id);
        }
    }
}
