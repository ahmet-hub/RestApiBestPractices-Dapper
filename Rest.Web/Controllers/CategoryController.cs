using Microsoft.AspNetCore.Mvc;
using Rest.Web.ApiService;
using Rest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryApiService _categoryApiService;
        public CategoryController(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryModel categoryModel)
        {
            await _categoryApiService.AddAsync(categoryModel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetAsync(id);
            await _categoryApiService.Update(category);
            //return RedirectToAction("Index");
            return View(category);

        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryModel categoryModel)
        {
            await _categoryApiService.Update(categoryModel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Remove(id);
            return RedirectToAction("Index");
        }


    }
}
