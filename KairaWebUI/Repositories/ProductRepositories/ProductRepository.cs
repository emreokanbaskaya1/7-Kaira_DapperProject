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

        public async Task DeleteAsync(int id)
        {
            string query = "Delete from products where ProductId = @ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            string query = "SELECT p.name, c.name as categoryName, price, imageUrl, Description, productId FROM Products as p inner join categories as c on c.CategoryId=p.CategoryId";
            return await _db.QueryAsync<ResultProductDto>(query);
        }

        public async Task<UpdateProductDto> GetByIdAsync(int id)
        {
            string query = "Select * from products where ProductId = @ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateProductDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateProductDto productDto)
        {
            string query = "Update products set name=@Name, ImageUrl=@ImageUrl, Description=@Description, price=@Price, categoryId=@CategoryId where ProductId=@ProductId";
            var parameters = new DynamicParameters(productDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
