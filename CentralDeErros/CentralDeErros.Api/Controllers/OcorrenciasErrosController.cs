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
    public class OcorrenciasErrosController : ControllerBase
    {
        private readonly ErroDbContext _context;

        public OcorrenciasErrosController(ErroDbContext context)
        {
            _context = context;
        }

        // GET: api/OcorrenciasErros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorOccurrence>>> GetOcorrenciaErros()
        {
            return await _context.OcorrenciaErros.ToListAsync();
        }

        // GET: api/OcorrenciasErros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorOccurrence>> GetOcorrenciaErro(int id)
        {
            var ocorrenciaErro = await _context.OcorrenciaErros.FindAsync(id);

            if (ocorrenciaErro == null)
            {
                return NotFound();
            }

            return ocorrenciaErro;
        }

        // PUT: api/OcorrenciasErros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcorrenciaErro(int id, ErrorOccurrence ocorrenciaErro)
        {
            if (id != ocorrenciaErro.Ocorrencia_Id)
            {
                return BadRequest();
            }

            _context.Entry(ocorrenciaErro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcorrenciaErroExists(id))
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

        // POST: api/OcorrenciasErros
        [HttpPost]
        public async Task<ActionResult<ErrorOccurrence>> PostOcorrenciaErro(ErrorOccurrence ocorrenciaErro)
        {
            _context.OcorrenciaErros.Add(ocorrenciaErro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOcorrenciaErro", new { id = ocorrenciaErro.Ocorrencia_Id }, ocorrenciaErro);
        }

        // DELETE: api/OcorrenciasErros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ErrorOccurrence>> DeleteOcorrenciaErro(int id)
        {
            var ocorrenciaErro = await _context.OcorrenciaErros.FindAsync(id);
            if (ocorrenciaErro == null)
            {
                return NotFound();
            }

            _context.OcorrenciaErros.Remove(ocorrenciaErro);
            await _context.SaveChangesAsync();

            return ocorrenciaErro;
        }

        private bool OcorrenciaErroExists(int id)
        {
            return _context.OcorrenciaErros.Any(e => e.Ocorrencia_Id == id);
        }
    }
}
