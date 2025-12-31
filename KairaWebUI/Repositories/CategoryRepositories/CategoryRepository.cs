using Dapper;
using KairaWebUI.Context;
using KairaWebUI.DTOs.CategoryDtos;
using System.Data;

namespace KairaWebUI.Repositories.CategoryRepositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();

        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            string query = "INSERT INTO categories (name) values (@Name)";
            var parameters = new DynamicParameters(categoryDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "Delete from categories where CategoryId = @CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            await _db.ExecuteAsync(query, parameters);
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

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var query = "UPDATE categories set name = @Name where CategoryId = @CategoryId";
            var parameters = new DynamicParameters(categoryDto);
            await _db.ExecuteAsync(query,parameters);

        }
    }
}
