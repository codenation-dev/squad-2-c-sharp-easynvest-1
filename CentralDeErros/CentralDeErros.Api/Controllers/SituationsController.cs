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
    public class SituationsController : ControllerBase
    {
        private readonly ISituation _service;
        private readonly IMapper _mapper;

        public SituationsController(ISituation service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Situations
        [HttpGet]
        public ActionResult<IEnumerable<Situation>> GetSituations()
        {
            var situations = _service.ConsultAllSituations();

            if (situations == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(situations.
                        Select(x => _mapper.Map<SituationDTO>(x)).
                        ToList());
            }
        }

        // GET: api/Situations/5
        [HttpGet("{id}")]
        public ActionResult<Situation> GetSituation(int id)
        {
            var situation = _service.ConsultSituation(id);

            if (situation == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SituationDTO>(situation));
        }

        // PUT: api/Situations/5
        [HttpPut("{id}")]
        public ActionResult<SituationDTO> PutSituation(int id, Situation situation)
        {
            if (id != situation.SituationId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<LevelDTO>(_service.RegisterOrUpdateSituation(situation)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.SituationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Situations
        [HttpPost]
        public ActionResult<Situation> PostSituation([FromBody] SituationDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<EnvironmentDTO>(_service.RegisterOrUpdateSituation(_mapper.Map<Situation>(value))));
        }
    }
}
