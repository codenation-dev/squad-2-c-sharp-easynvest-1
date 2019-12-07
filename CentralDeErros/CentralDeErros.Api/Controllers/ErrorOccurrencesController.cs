using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using CentralDeErros.Api.Interfaces;
using AutoMapper;
using CentralDeErros.Api.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ErrorOccurrencesController : ControllerBase
    {
        private readonly IErrorOccurrence _service;
        private readonly IMapper _mapper;

        public ErrorOccurrencesController(IErrorOccurrence service, IMapper mapper)
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

        // GET: api/ErrorOccurrences/Level=1
        [HttpGet("Level={levelId}")]
        public ActionResult<IEnumerable<ErrorOccurrenceDTO>> GetErrorOccurrencesByLevel(int levelId)
        {
            var errorOccurrences = _service.ListOccurencesByLevel(levelId);

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

        // GET: api/ErrorOccurrences/Archive/1
        [HttpPut("File/{id}")]
        public ActionResult<IEnumerable<ErrorOccurrenceDTO>> ArchiveErrorOccurrence (int id, ErrorOccurrence errorOccurrence)
        {
            if (id != errorOccurrence.ErrorOccurrenceId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<ErrorOccurrenceDTO>(_service.RegisterOrUpdateErrorOccurrence(errorOccurrence)));
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

        //GET: api/Errors/1/2/0/0
        //[HttpGet("Environment={ambiente}&&OrderBy={campoOrdenacao}&&Field={campoBuscado}&&Search={textoBuscado}")]
        [HttpGet("{ambiente}/{campoOrdenacao}/{campoBuscado}/{textoBuscado}")]
        public ActionResult<List<ErrorOccurrenceDTO>> GetErrorFilter(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            var errorOccurrences = _service.Consult(ambiente, campoOrdenacao, campoBuscado, textoBuscado);

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
        [HttpGet("{id}")]
        public ActionResult<ErrorOccurrenceDTO> GetErrorOccurrence(int id)
        {
            var errorOccurrence = _service.ConsultErrorOccurrenceById(id);

            if (errorOccurrence == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ErrorOccurrenceDTO>(errorOccurrence));
        }

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
                return Ok(_mapper.Map<ErrorOccurrenceDTO>(_service.RegisterOrUpdateErrorOccurrence(errorOccurrence)));
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
