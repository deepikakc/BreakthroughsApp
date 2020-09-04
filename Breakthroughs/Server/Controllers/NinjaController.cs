using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Breakthroughs.Server.Data.Ninjas;
using Breakthroughs.Shared.Dtos;
using Breakthroughs.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Breakthroughs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NinjaController : ControllerBase
    {
        private readonly INinjaRepo ninjaRepo;
        private readonly IMapper mapper;

        public NinjaController(INinjaRepo ninjaRepo, IMapper mapper)
        {
            this.ninjaRepo = ninjaRepo;
            this.mapper = mapper;
        }

        // GET: api/ninja/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<NinjaReadDto>> GetNinjaById(int id)
        {
            try
            {
                var result = await ninjaRepo.GetNinjaById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return mapper.Map<NinjaReadDto>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving ninja id={id} data from database");
            }
        }

        // GET: api/ninja/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<NinjaReadDto>>> GetNinjaList()
        {
            try
            {
                var result = await ninjaRepo.GetNinjaList();
                return Ok(mapper.Map<IEnumerable<NinjaReadDto>>(result));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving ninja list data from database");
            }
        }
    }
}
