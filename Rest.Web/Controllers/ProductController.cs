using Microsoft.AspNetCore.Mvc;
using Rest.Web.ApiService;
using Rest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;
        public ProductController(ProductApiService productApiService,CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productApiService.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Category = await _categoryApiService.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel productModel)
        {
            var products = await _productApiService.AddAsync(productModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var products = await _productApiService.GetAsync(id);
            await _productApiService.Update(products);
            ViewBag.Category = await _categoryApiService.GetAllAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel productModel)
        {
            var products = await _productApiService.Update(productModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var products = await _productApiService.Remove(id);
            return RedirectToAction("Index");

        }

    }
}
