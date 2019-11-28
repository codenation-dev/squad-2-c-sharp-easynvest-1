using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using CentralDeErros.Api.Services;
using CentralDeErros.Api.DTOs;
using AutoMapper;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentsController : ControllerBase
    {
        private readonly ErrorDbContext _context;
        private readonly IEnvironment _service;
        private readonly IMapper _mapper;

        public EnvironmentsController(IMapper mapper, IEnvironment service)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Environments
        [HttpGet]
        public ActionResult<IEnumerable<EnvironmentDTO>> GetEnvironments()
        {
            return Ok(_mapper.Map<EnvironmentDTO>(_service.ConsultAllEnvironments()));
        }

        // GET: api/Environments/5
        [HttpGet("{id}")]
        public ActionResult<EnvironmentDTO> GetEnvironment(int id)
        {
            var environment = _service.ConsultEnvironment(id);

            if (environment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EnvironmentDTO>(environment));
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
        public ActionResult<EnvironmentDTO> PostEnvironment([FromBody] EnvironmentDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<EnvironmentDTO>(_service.RegisterEnvironment(_mapper.Map<Models.Environment>(value))));

        }

        //// DELETE: api/Environments/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Models.Environment>> DeleteEnvironment(int id)
        //{
        //    var environment = await _context.Environments.FindAsync(id);
        //    if (environment == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Environments.Remove(environment);
        //    await _context.SaveChangesAsync();

        //    return environment;
        //}

        private bool EnvironmentExists(int id)
        {
            return _context.Environments.Any(e => e.Environment_Id == id);
        }
    }
}
