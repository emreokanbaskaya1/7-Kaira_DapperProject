using KairaWebUI.DTOs.CategoryDtos;
using KairaWebUI.Helpers;
using KairaWebUI.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(ICategoryRepository _categoryRepository) : Controller
    {
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var paginatedList = PaginatedList<ResultCategoryDto>.Create(categories, pageNumber, pageSize);
            return View(paginatedList);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            await _categoryRepository.CreateAsync(categoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            await _categoryRepository.UpdateAsync(categoryDto);
            return RedirectToAction("Index");
        }
    }
}
