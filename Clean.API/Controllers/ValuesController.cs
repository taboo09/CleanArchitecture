﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clean.Data.Interfaces;
using Clean.Data.Entities;
using Clean.Data.Dtos;
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
            // return new string[] { "value1", "value2" };
            return Ok(await _appRepo.ListAllAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(HomeDto homeDto)
        {
            if(ModelState.IsValid) {
                var home = _mapper.Map<Homes>(homeDto);

                _appRepo.Add(home);

                await _appRepo.SaveAllAsync();

                return Ok(home);
            }

            return BadRequest("Objects values don't match");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
