using Dapper;
using KairaWebUI.Context;
using KairaWebUI.DTOs.CollectionDtos;
using System.Data;

namespace KairaWebUI.Repositories.CollectionRepositories
{
    public class CollectionRepository(AppDbContext context) : ICollectionRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateCollectionDto collectionDto)
        {
            string query = "INSERT INTO collections (ImageUrl, Title, Description) values (@ImageUrl, @Title, @Description)";
            var parameters = new DynamicParameters(collectionDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "Delete from collections where CollectionId = @CollectionId";
            var parameters = new DynamicParameters();
            parameters.Add("@CollectionId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCollectionDto>> GetAllAsync()
        {
            string query = "SELECT * from collections";
            return await _db.QueryAsync<ResultCollectionDto>(query);
        }

        public async Task<UpdateCollectionDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Collections where CollectionId = @CollectionId";
            var parameters = new DynamicParameters();
            parameters.Add("@CollectionId", id);
            return await _db.QueryFirstOrDefault(query, parameters);
        }

        public async Task UpdateAsync(UpdateCollectionDto collectionDto)
        {
            string query = "Update collections set ImageUrl = @ImageUrl, Title= @Title, Description = @Description where CollectionId= @CollectionId";
            var parameters = new DynamicParameters(collectionDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
