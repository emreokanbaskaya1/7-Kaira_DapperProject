using KairaWebUI.DTOs.TestimonialDtos;
using KairaWebUI.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(ITestimonialRepository _testimonialRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var testimonials = await _testimonialRepository.GetAllAsync();
            return View(testimonials);
        }


        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonial)
        {
            await _testimonialRepository.CreateAsync(createTestimonial);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _testimonialRepository.GetByIdAsync(id);
            return View(testimonial);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonial)
        {
            await _testimonialRepository.UpdateAsync(updateTestimonial);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
