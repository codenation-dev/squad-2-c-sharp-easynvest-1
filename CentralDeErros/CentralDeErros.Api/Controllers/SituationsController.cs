using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SituationsController : ControllerBase
    {
        private readonly ErrorDbContext _context;

        public SituationsController(ErrorDbContext context)
        {
            _context = context;
        }

        // GET: api/Situations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Situation>>> GetSituations()
        {
            return await _context.Situations.ToListAsync();
        }

        // GET: api/Situations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Situation>> GetSituation(int id)
        {
            var situation = await _context.Situations.FindAsync(id);

            if (situation == null)
            {
                return NotFound();
            }

            return situation;
        }

        // PUT: api/Situations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituation(int id, Situation situation)
        {
            if (id != situation.SituationId)
            {
                return BadRequest();
            }

            _context.Entry(situation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituationExists(id))
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

        // POST: api/Situations
        [HttpPost]
        public async Task<ActionResult<Situation>> PostSituation(Situation situation)
        {
            _context.Situations.Add(situation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSituation", new { id = situation.SituationId }, situation);
        }

        // DELETE: api/Situations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Situation>> DeleteSituation(int id)
        {
            var situation = await _context.Situations.FindAsync(id);
            if (situation == null)
            {
                return NotFound();
            }

            _context.Situations.Remove(situation);
            await _context.SaveChangesAsync();

            return situation;
        }

        private bool SituationExists(int id)
        {
            return _context.Situations.Any(e => e.SituationId == id);
        }
    }
}
