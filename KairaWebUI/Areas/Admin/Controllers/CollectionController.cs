using KairaWebUI.DTOs.CollectionDtos;
using KairaWebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KairaWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CollectionController(ICollectionRepository _collectionRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collections = await _collectionRepository.GetAllAsync();
            return View(collections);
        }


        public async Task<IActionResult> CreateCollection()
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
