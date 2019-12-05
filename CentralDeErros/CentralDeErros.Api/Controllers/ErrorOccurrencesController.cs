using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using CentralDeErros.Api.Interfaces;
using AutoMapper;
using CentralDeErros.Api.DTOs;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorOccurrencesController : ControllerBase
    {
        private readonly IErrorOccurrence _service;
        private readonly IMapper _mapper;

        private ErrorOccurrencesController(IErrorOccurrence service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/ErrorOccurrences
        [HttpGet]
        public ActionResult<IEnumerable<ErrorOccurrenceDTO>> GetErrorOccurrences()
        {
            var errorOccurrences = _service.ListOccurencesByLevel(1);

            if (errorOccurrences == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(errorOccurrences.
                        Select(x => _mapper.Map<ErrorOccurrenceDTO>(x)).
                        ToList());
            }
        }

        // GET: api/ErrorOccurrences/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ErrorOccurrence>> GetErrorOccurrence(int id)
        //{
        //    var errorOccurrence = await _context.ErrorOccurrences.FindAsync(id);

        //    if (errorOccurrence == null)
        //    {
        //        return NotFound();
        //    }

        //    return errorOccurrence;
        //}

        // PUT: api/ErrorOccurrences/5
        [HttpPut("{id}")]
        public ActionResult<ErrorOccurrenceDTO> PutErrorOccurrence(int id, ErrorOccurrence errorOccurrence)
        {
            if (id != errorOccurrence.ErrorOccurrenceId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<ErrorDTO>(_service.RegisterOrUpdateErrorOccurrence(errorOccurrence)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.ErrorOccurrenceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/ErrorOccurrences
        [HttpPost]
        public ActionResult<ErrorOccurrence> PostErrorOccurrence([FromBody] ErrorOccurrenceDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<ErrorOccurrenceDTO>(_service.RegisterOrUpdateErrorOccurrence(_mapper.Map<ErrorOccurrence>(value))));
        }
    }
}
