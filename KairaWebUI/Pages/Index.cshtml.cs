using KairaWebUI.DTOs.CollectionDtos;
using KairaWebUI.DTOs.ProductDtos;
using KairaWebUI.DTOs.TestimonialDtos;
using KairaWebUI.DTOs.VideoDtos;
using KairaWebUI.Repositories.CollectionRepositories;
using KairaWebUI.Repositories.ProductRepositories;
using KairaWebUI.Repositories.TestimonialRepositories;
using KairaWebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KairaWebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IProductRepository _productRepository;
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IVideoRepository _videoRepository;

        public IndexModel(
            ICollectionRepository collectionRepository,
            IProductRepository productRepository,
            ITestimonialRepository testimonialRepository,
            IVideoRepository videoRepository)
        {
            _collectionRepository = collectionRepository;
            _productRepository = productRepository;
            _testimonialRepository = testimonialRepository;
            _videoRepository = videoRepository;
        }

        public IEnumerable<ResultCollectionDto> Collections { get; set; }
        public IEnumerable<ResultProductDto> Products { get; set; }
        public IEnumerable<ResultTestimonialDto> Testimonials { get; set; }
        public IEnumerable<ResultVideoDto> Videos { get; set; }

        public async Task OnGetAsync()
        {
            Collections = await _collectionRepository.GetAllAsync();
            Products = await _productRepository.GetAllAsync();
            Testimonials = await _testimonialRepository.GetAllAsync();
            Videos = await _videoRepository.GetAllAsync();
        }
    }
}
