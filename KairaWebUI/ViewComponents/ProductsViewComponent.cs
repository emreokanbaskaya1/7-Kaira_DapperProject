using KairaWebUI.DTOs.ProductDtos;
using KairaWebUI.Repositories.ProductRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IProductRepository _productRepository;

        public ProductsViewComponent(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }
    }
}
