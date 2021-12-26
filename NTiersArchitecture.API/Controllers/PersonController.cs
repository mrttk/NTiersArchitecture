using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTiersArchitecture.API.DTOs;
using NTiersArchitecture.Core.Entity;
using NTiersArchitecture.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTiersArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _service;
        private readonly IMapper _mapper;

        public PersonController(IService<Person> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var person = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(person));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<PersonDto>(person));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var createdPerson = await _service.AddAsync(_mapper.Map<Person>(personDto));
            return Created(string.Empty, createdPerson);
        }

        [HttpPut]
        public IActionResult Update(PersonDto personDto)
        {
            _service.Update(_mapper.Map<Person>(personDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var person = _service.GetByIdAsync(id).Result;
            _service.Remove(person);

            return NoContent();
        }
    }
}
