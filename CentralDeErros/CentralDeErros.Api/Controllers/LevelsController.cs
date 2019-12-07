using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using CentralDeErros.Api.Interfaces;
using AutoMapper;
using CentralDeErros.Api.DTOs;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LevelsController : ControllerBase
    {
        private readonly ILevel _service;
        private readonly IMapper _mapper;

        public LevelsController(ILevel service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // GET: api/Levels
        [HttpGet]
        public ActionResult<IEnumerable<LevelDTO>> GetLevels()
        {
            var levels = _service.ConsultAllLevels();

            if (levels == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(levels.
                        Select(x => _mapper.Map<LevelDTO>(x)).
                        ToList());
            }
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public ActionResult<LevelDTO> GetLevel(int id)
        {
            var level = _service.ConsultLevelById(id);

            if (level == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<LevelDTO>(level));
        }

        // PUT: api/Levels/5
        [HttpPut("{id}")]
        public ActionResult<LevelDTO> PutLevel(int id, Level level)
        {
            if (id != level.LevelId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<LevelDTO>(_service.RegisterOrUpdateLevel(level)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.LevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Levels
        [HttpPost]
        public ActionResult<LevelDTO> PostLevel([FromBody] LevelDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<LevelDTO>(_service.RegisterOrUpdateLevel(_mapper.Map<Level>(value))));
        }
    }
}
