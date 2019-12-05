using System.Collections.Generic;
using System.Linq;
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
    public class ErrorsController : ControllerBase
    {
        private readonly IError _service;
        private readonly IMapper _mapper;

        public ErrorsController(IError service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Errors
        [HttpGet]
        public ActionResult<IEnumerable<ErrorDTO>> GetErrors()
        {
            var errors = _service.ConsultAllErrors();

            if (errors == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(errors.
                        Select(x => _mapper.Map<ErrorDTO>(x)).
                        ToList());
            }
        }

        // GET: api/Errors/5
        [HttpGet("{id}")]
        public ActionResult<Error> GetError(int id)
        {
            var error = _service.ConsultError(id);

            if (error == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ErrorDTO>(error));
        }

        // PUT: api/Errors/5
        [HttpPut("{id}")]
        public ActionResult<ErrorDTO> PutError(int id, Error error)
        {
            if (id != error.ErrorId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<ErrorDTO>(_service.RegisterOrUpdateError(error)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.ErrorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Errors
        [HttpPost]
        public ActionResult<Error> PostError([FromBody] ErrorDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<ErrorDTO>(_service.RegisterOrUpdateError(_mapper.Map<Error>(value))));
        }
    }
}
