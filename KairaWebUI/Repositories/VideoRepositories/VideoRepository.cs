using Dapper;
using KairaWebUI.Context;
using KairaWebUI.DTOs.VideoDtos;
using System.Data;

namespace KairaWebUI.Repositories.VideoRepositories
{
    public class VideoRepository(AppDbContext context) : IVideoRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();

        public async Task CreateAsync(CreateVideoDto videoDto)
        {
            string query = "INSERT INTO Videos (Url, BackgroundImageUrl) VALUES (@Url, @BackgroundImageUrl)";
            var parameters = new DynamicParameters(videoDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Videos WHERE VideoId = @VideoId";
            var parameters = new DynamicParameters();
            parameters.Add("@VideoId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultVideoDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Videos";
            return await _db.QueryAsync<ResultVideoDto>(query);
        }

        public async Task<UpdateVideoDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Videos WHERE VideoId = @VideoId";
            var parameters = new DynamicParameters();
            parameters.Add("@VideoId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateVideoDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateVideoDto videoDto)
        {
            string query = "UPDATE Videos SET Url = @Url, BackgroundImageUrl = @BackgroundImageUrl WHERE VideoId = @VideoId";
            var parameters = new DynamicParameters(videoDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
