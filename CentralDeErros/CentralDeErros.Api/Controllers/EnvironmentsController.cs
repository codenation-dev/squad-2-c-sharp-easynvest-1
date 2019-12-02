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
    public class EnvironmentsController : ControllerBase
    {
        private readonly ErrorDbContext _context;

        public EnvironmentsController(ErrorDbContext context)
        {
            _context = context;
        }

        // GET: api/Environments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Environment>>> GetEnvironments()
        {
            return await _context.Environments.ToListAsync();
        }

        // GET: api/Environments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Environment>> GetEnvironment(int id)
        {
            var environment = await _context.Environments.FindAsync(id);

            if (environment == null)
            {
                return NotFound();
            }

            return environment;
        }

        // PUT: api/Environments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvironment(int id, Models.Environment environment)
        {
            if (id != environment.Environment_Id)
            {
                return BadRequest();
            }

            _context.Entry(environment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvironmentExists(id))
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

        // POST: api/Environments
        [HttpPost]
        public async Task<ActionResult<Models.Environment>> PostEnvironment(Models.Environment environment)
        {
            _context.Environments.Add(environment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvironment", new { id = environment.Environment_Id }, environment);
        }

        // DELETE: api/Environments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Environment>> DeleteEnvironment(int id)
        {
            var environment = await _context.Environments.FindAsync(id);
            if (environment == null)
            {
                return NotFound();
            }

            _context.Environments.Remove(environment);
            await _context.SaveChangesAsync();

            return environment;
        }

        private bool EnvironmentExists(int id)
        {
            return _context.Environments.Any(e => e.Environment_Id == id);
        }
    }
}
