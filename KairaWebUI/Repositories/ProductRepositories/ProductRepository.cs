using Dapper;
using KairaWebUI.Context;
using KairaWebUI.DTOs.ProductDtos;
using System.Data;

namespace KairaWebUI.Repositories.ProductRepositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateProductDto productDto)
        {
            string query = "INSERT INTO products (name, imageUrl, description, price, categoryId) values (@Name, @ImageUrl, @Description, @Price, @CategoryId)";
            var parameters = new DynamicParameters(productDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UpdateProductDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
