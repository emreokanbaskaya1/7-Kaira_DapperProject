using KairaWebUI.DTOs.VideoDtos;

namespace KairaWebUI.Repositories.VideoRepositories
{
    public interface IVideoRepository
    {
        Task<IEnumerable<ResultVideoDto>> GetAllAsync();
        Task<UpdateVideoDto> GetByIdAsync(int id);
        Task CreateAsync(CreateVideoDto videoDto);
        Task UpdateAsync(UpdateVideoDto videoDto);
        Task DeleteAsync(int id);
    }
}
