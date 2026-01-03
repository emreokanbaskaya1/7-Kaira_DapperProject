using KairaWebUI.DTOs.CollectionDtos;

namespace KairaWebUI.Repositories.CollectionRepositories
{
    public interface ICollectionRepository
    {
        Task<IEnumerable<ResultCollectionDto>> GetAllAsync();
        Task<UpdateCollectionDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCollectionDto collectionDto);
        Task UpdateAsync(UpdateCollectionDto collectionDto);
        Task DeleteAsync(int id);
    }
}
