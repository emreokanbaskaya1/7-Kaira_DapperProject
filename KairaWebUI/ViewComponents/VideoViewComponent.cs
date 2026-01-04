using KairaWebUI.DTOs.VideoDtos;
using KairaWebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc;

namespace KairaWebUI.ViewComponents
{
    public class VideoViewComponent : ViewComponent
    {
        private readonly IVideoRepository _videoRepository;

        public VideoViewComponent(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var videos = await _videoRepository.GetAllAsync();
            return View(videos);
        }
    }
}
