using AHIOTAM_Api.Dtos.HomePageAboutDto;
using AHIOTAM_Api.Models.Context;
using Dapper;

namespace AHIOTAM_Api.Repositories.HomePageAboutRepository
{
    public class HomePageAboutRepository : IHomePageAboutRepository
    {
        private readonly Context _context;

        public HomePageAboutRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateAboutAsync(CreateHomePageAboutDto createAboutDto)
        {
            string query = "INSERT INTO HomePageAbout (Title, Description,AboutImageUrl) VALUES (@title, @description,@aboutImageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createAboutDto.Title);
            parameters.Add("@description", createAboutDto.Description);
            parameters.Add("@aboutImageUrl", createAboutDto.AboutImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteAboutAsync(int id)
        {
            string query = "Delete from HomePageAbout where AboutId = @aboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@aboutId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultHomePageAboutDto>> GetAllAboutAsync()
        {
            string query = "SELECT * FROM HomePageAbout";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultHomePageAboutDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultHomePageAboutDto> GetByIdAsync(int id)
        {
            string query = "Select * from HomePageAbout where AboutId = @aboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@aboutId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultHomePageAboutDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateAboutAsync(UpdateHomePageAboutDto updateAboutDto)
        {
            string query = "Update HomePageAbout set Title = @title, Description = @description,AboutImageUrl = @aboutImageUrl where AboutId = @AboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateAboutDto.Title);
            parameters.Add("@description", updateAboutDto.Description);
            parameters.Add("@aboutImageUrl", updateAboutDto.AboutImageUrl);
            parameters.Add("@aboutId", updateAboutDto.AboutId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
