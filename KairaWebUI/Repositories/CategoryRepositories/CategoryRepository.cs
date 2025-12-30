using Dapper;
using KairaWebUI.Context;
using KairaWebUI.DTOs.CategoryDtos;
using System.Data;

namespace KairaWebUI.Repositories.CategoryRepositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();

        public Task CreateAsync(CreateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Categories";
            return await _db.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Categories WHERE CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCategoryDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
