using Dapper;
using KairaWebUI.Context;
using KairaWebUI.DTOs.TestimonialDtos;
using System.Data;

namespace KairaWebUI.Repositories.TestimonialRepositories
{
    public class TestimonialRepository(AppDbContext context) : ITestimonialRepository
    {
        private readonly IDbConnection _db = context.CreateConnection();
        public async Task CreateAsync(CreateTestimonialDto testimonialDto)
        {
            string query = "INSERT INTO Testimonials (NameSurname, Comment) values (@NameSurname, @Comment)";
            var parameters = new DynamicParameters(testimonialDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Testimonials WHERE TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultTestimonialDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Testimonials";
            return await _db.QueryAsync<ResultTestimonialDto>(query);

        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Testimonials WHERE TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateTestimonialDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateTestimonialDto testimonialDto)
        {
            string query = "UPDATE Testimonials SET NameSurname=@NameSurname, Comment=@Comment WHERE TestimonialId=@TestimonialId";
            var parameters = new DynamicParameters(testimonialDto);
            await _db.ExecuteAsync(query, parameters);
            
        }
    }
}
