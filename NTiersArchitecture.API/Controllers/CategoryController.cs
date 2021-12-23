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

namespace APINew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var createdCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return Created("", _mapper.Map<CategoryDto>(createdCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return NoContent();
        }
    }
}
