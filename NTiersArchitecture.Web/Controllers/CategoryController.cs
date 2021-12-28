using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTiersArchitecture.Web.DTOs;
using NTiersArchitecture.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTiersArchitecture.Core.Entity;

namespace NTiersArchitecture.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return RedirectToAction("Index");
        }
    }
}
