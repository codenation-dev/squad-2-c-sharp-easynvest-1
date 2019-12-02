﻿using System;
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
    public class ErrorOccurrencesController : ControllerBase
    {
        private readonly ErrorDbContext _context;

        public ErrorOccurrencesController(ErrorDbContext context)
        {
            _context = context;
        }

        // GET: api/ErrorOccurrences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorOccurrence>>> GetErrorOccurrences()
        {
            return await _context.ErrorOccurrences.ToListAsync();
        }

        // GET: api/ErrorOccurrences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorOccurrence>> GetErrorOccurrence(int id)
        {
            var errorOccurrence = await _context.ErrorOccurrences.FindAsync(id);

            if (errorOccurrence == null)
            {
                return NotFound();
            }

            return errorOccurrence;
        }

        // PUT: api/ErrorOccurrences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErrorOccurrence(int id, ErrorOccurrence errorOccurrence)
        {
            if (id != errorOccurrence.ErrorOccurrenceId)
            {
                return BadRequest();
            }

            _context.Entry(errorOccurrence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorOccurrenceExists(id))
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

        // POST: api/ErrorOccurrences
        [HttpPost]
        public async Task<ActionResult<ErrorOccurrence>> PostErrorOccurrence(ErrorOccurrence errorOccurrence)
        {
            _context.ErrorOccurrences.Add(errorOccurrence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErrorOccurrence", new { id = errorOccurrence.ErrorOccurrenceId }, errorOccurrence);
        }

        // DELETE: api/ErrorOccurrences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ErrorOccurrence>> DeleteErrorOccurrence(int id)
        {
            var errorOccurrence = await _context.ErrorOccurrences.FindAsync(id);
            if (errorOccurrence == null)
            {
                return NotFound();
            }

            _context.ErrorOccurrences.Remove(errorOccurrence);
            await _context.SaveChangesAsync();

            return errorOccurrence;
        }

        private bool ErrorOccurrenceExists(int id)
        {
            return _context.ErrorOccurrences.Any(e => e.ErrorOccurrenceId == id);
        }
    }
}
