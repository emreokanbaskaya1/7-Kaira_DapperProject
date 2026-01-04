using KairaWebUI.DTOs.CollectionDtos;
using KairaWebUI.Repositories.CollectionRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.ViewComponents
{
    public class BillboardViewComponent : ViewComponent
    {
        private readonly ICollectionRepository _collectionRepository;

        public BillboardViewComponent(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var collections = await _collectionRepository.GetAllAsync();
            return View(collections);
        }
    }
}
