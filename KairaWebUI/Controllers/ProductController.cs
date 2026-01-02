using KairaWebUI.DTOs.ProductDtos;
using KairaWebUI.Repositories.CategoryRepositories;
using KairaWebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace KairaWebUI.Controllers
{
    public class ProductController(IProductRepository _productRepository,
                                   ICategoryRepository _categoryRepository) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.Name,
                                      Value = category.CategoryId.ToString()
                                  }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
        {
            await _productRepository.CreateAsync(productDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            await GetCategoriesAsync();
            var products = await _productRepository.GetByIdAsync(id);
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            await _productRepository.UpdateAsync(productDto);
            return RedirectToAction("Index");
        }

    }
}
