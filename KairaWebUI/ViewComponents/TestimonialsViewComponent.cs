using KairaWebUI.DTOs.TestimonialDtos;
using KairaWebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.ViewComponents
{
    public class TestimonialsViewComponent : ViewComponent
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialsViewComponent(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _testimonialRepository.GetAllAsync();
            return View(testimonials);
        }
    }
}
