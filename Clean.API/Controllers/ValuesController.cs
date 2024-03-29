﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clean.Data.Interfaces;
using Clean.Data.Entities;
using Clean.Infrastructure.Dtos;
using AutoMapper;

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IAppRepository<Homes> _appRepo;
        private readonly IMapper _mapper;
        public ValuesController(IAppRepository<Homes> appRepo, IMapper mapper)
        {
            _appRepo = appRepo;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _appRepo.ListAllAsync();

            return Ok(list);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return BadRequest("Id hasn't been provided");

            var home = await _appRepo.GetByIdAsync(id);

            if (home == null) return NotFound(new { error = $"No home could be found with id: {id}" });

            return Ok(home);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(HomeDto homeDto)
        {
            if(ModelState.IsValid) {
                var home = _mapper.Map<Homes>(homeDto);

                var newHome = _appRepo.Add(home);

                await _appRepo.SaveAllAsync();

                return Ok(home);
            }

            return BadRequest("Validation error");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest("Id hasn't been provided");

            var home = await _appRepo.GetByIdAsync(id);

            if (home == null) return NotFound(new { error = $"No home could be found with id: {id}" });

            _appRepo.Delete(home);

            await _appRepo.SaveAllAsync();

            return Ok($"Home with id: {id} has been removed.");
        }
    }
}
