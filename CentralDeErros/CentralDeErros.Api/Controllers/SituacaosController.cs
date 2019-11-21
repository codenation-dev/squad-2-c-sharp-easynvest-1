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
    public class SituacaosController : ControllerBase
    {
        private readonly ErroDbContext _context;

        public SituacaosController(ErroDbContext context)
        {
            _context = context;
        }

        // GET: api/Situacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Situacao>>> GetSituacoes()
        {
            return await _context.Situacoes.ToListAsync();
        }

        // GET: api/Situacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Situacao>> GetSituacao(int id)
        {
            var situacao = await _context.Situacoes.FindAsync(id);

            if (situacao == null)
            {
                return NotFound();
            }

            return situacao;
        }

        // PUT: api/Situacaos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituacao(int id, Situacao situacao)
        {
            if (id != situacao.Situacao_Id)
            {
                return BadRequest();
            }

            _context.Entry(situacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituacaoExists(id))
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

        // POST: api/Situacaos
        [HttpPost]
        public async Task<ActionResult<Situacao>> PostSituacao(Situacao situacao)
        {
            _context.Situacoes.Add(situacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSituacao", new { id = situacao.Situacao_Id }, situacao);
        }

        // DELETE: api/Situacaos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Situacao>> DeleteSituacao(int id)
        {
            var situacao = await _context.Situacoes.FindAsync(id);
            if (situacao == null)
            {
                return NotFound();
            }

            _context.Situacoes.Remove(situacao);
            await _context.SaveChangesAsync();

            return situacao;
        }

        private bool SituacaoExists(int id)
        {
            return _context.Situacoes.Any(e => e.Situacao_Id == id);
        }
    }
}
