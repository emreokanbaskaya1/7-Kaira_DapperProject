using KairaWebUI.DTOs.CollectionDtos;
using KairaWebUI.Helpers;
using KairaWebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CollectionController(ICollectionRepository _collectionRepository) : Controller
    {
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var collections = await _collectionRepository.GetAllAsync();
            var paginatedList = PaginatedList<ResultCollectionDto>.Create(collections, pageNumber, pageSize);
            return View(paginatedList);
        }

        public IActionResult CreateCollection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection(CreateCollectionDto createCollection)
        {
            await _collectionRepository.CreateAsync(createCollection);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCollection(int id)
        {
            var collection = await _collectionRepository.GetByIdAsync(id);
            return View(collection);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCollection(UpdateCollectionDto updateCollection)
        {
            await _collectionRepository.UpdateAsync(updateCollection);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCollection(int id)
        {
            await _collectionRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
