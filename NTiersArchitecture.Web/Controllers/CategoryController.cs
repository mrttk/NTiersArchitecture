using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTiersArchitecture.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTiersArchitecture.Core.Entity;
using NTiersArchitecture.Core.Services;
using NTiersArchitecture.Web.Filters;
using NTiersArchitecture.Web.ApiServices;

namespace NTiersArchitecture.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryApiService _categoryApiService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(CategoryApiService categoryApiService, ICategoryService categoryService, IMapper mapper)
        {
            _categoryApiService = categoryApiService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
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

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return View();
        }

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);

            return RedirectToAction("Index");
        }
    }
}
