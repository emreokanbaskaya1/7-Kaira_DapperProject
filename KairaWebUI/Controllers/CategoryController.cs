using KairaWebUI.Repositories.CategoryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.Controllers
{
    public class CategoryController(ICategoryRepository _categoryRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }
    }
}
