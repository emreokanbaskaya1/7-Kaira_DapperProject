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


    }
}
