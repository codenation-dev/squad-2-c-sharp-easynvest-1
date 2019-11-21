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
    public class AmbientesController : ControllerBase
    {
        private readonly ErroDbContext _context;

        public AmbientesController(ErroDbContext context)
        {
            _context = context;
        }

        // GET: api/Ambiente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ambiente>>> GetAmbientes()
        {
            return await _context.Ambientes.ToListAsync();
        }

        // GET: api/Ambiente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ambiente>> GetAmbiente(int id)
        {
            var ambiente = await _context.Ambientes.FindAsync(id);

            if (ambiente == null)
            {
                return NotFound();
            }

            return ambiente;
        }

        // PUT: api/Ambiente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmbiente(int id, Ambiente ambiente)
        {
            if (id != ambiente.Ambiente_Id)
            {
                return BadRequest();
            }

            _context.Entry(ambiente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmbienteExists(id))
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

        // POST: api/Ambiente
        [HttpPost]
        public async Task<ActionResult<Ambiente>> PostAmbiente(Ambiente ambiente)
        {
            _context.Ambientes.Add(ambiente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmbiente", new { id = ambiente.Ambiente_Id }, ambiente);
        }

        // DELETE: api/Ambiente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ambiente>> DeleteAmbiente(int id)
        {
            var ambiente = await _context.Ambientes.FindAsync(id);
            if (ambiente == null)
            {
                return NotFound();
            }

            _context.Ambientes.Remove(ambiente);
            await _context.SaveChangesAsync();

            return ambiente;
        }

        private bool AmbienteExists(int id)
        {
            return _context.Ambientes.Any(e => e.Ambiente_Id == id);
        }
    }
}
