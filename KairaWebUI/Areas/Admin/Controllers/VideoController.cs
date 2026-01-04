using KairaWebUI.DTOs.VideoDtos;
using KairaWebUI.Helpers;
using KairaWebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoController(IVideoRepository _videoRepository) : Controller
    {
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var videos = await _videoRepository.GetAllAsync();
            var paginatedList = PaginatedList<ResultVideoDto>.Create(videos, pageNumber, pageSize);
            return View(paginatedList);
        }

        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoDto createVideo)
        {
            await _videoRepository.CreateAsync(createVideo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateVideo(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto updateVideo)
        {
            await _videoRepository.UpdateAsync(updateVideo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteVideo(int id)
        {
            await _videoRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
