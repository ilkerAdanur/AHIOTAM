using AHIOTAM_Api.Dtos.MenuDetailDto;
using AHIOTAM_Api.Models.Context;
using Dapper;

namespace AHIOTAM_Api.Repositories.MenuDetailRepositories
{
    public class MenuDetailRepository : IMenuDetailRepository
    {
        private readonly Context _context;

        public MenuDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateMenuDetail(CreateMenuDetailDto createMenuDetailDto)
        {
            string query = "INSERT INTO MenuDetail (PreparationTime, Calories, AllergenInfo,IsSpicy,AdditionalNotes) VALUES (@preparationTime, @calories, @allergenInfo,@isSpicy,@additionalNotes)";
            var parameters = new DynamicParameters();
            parameters.Add("@preparationTime", createMenuDetailDto.PreparationTime);
            parameters.Add("@calories", createMenuDetailDto.Calories);
            parameters.Add("@allergenInfo", createMenuDetailDto.AllergenInfo);
            parameters.Add("@isSpicy", createMenuDetailDto.IsSpicy);
            parameters.Add("@additionalNotes", createMenuDetailDto.AdditionalNotes);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteMenuDetail(int id)
        {
            string query = "DELETE FROM MenuDetail WHERE MenuDetailId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<List<ResultMenuDetailDto>> GetAllMenuDetail()
        {
            string query = "SELECT * FROM MenuDetail";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultMenuDetailDto>(query);
                return result.ToList();
            }
        }
        public async Task<GetByIdMenuDetailDto> GetMenuDetailById(int id)
        {
            string query = "SELECT * FROM MenuDetail WHERE MenuDetailId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<GetByIdMenuDetailDto>(query, parameters);
                return result;
            }
        }
        public async Task UpdateMenuDetail(UpdateMenuDetailDto updateMenuDetailDto)
        {
            string query = "UPDATE MenuDetail SET PreparationTime = @preparationTime, Calories = @calories, AllergenInfo = @allergenInfo, IsSpicy = @isSpicy, AdditionalNotes = @additionalNotes WHERE MenuDetailId = @menuDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@menuDetailId", updateMenuDetailDto.MenuDetailId);
            parameters.Add("@preparationTime", updateMenuDetailDto.PreparationTime);
            parameters.Add("@calories", updateMenuDetailDto.Calories);
            parameters.Add("@allergenInfo", updateMenuDetailDto.AllergenInfo);
            parameters.Add("@isSpicy", updateMenuDetailDto.IsSpicy);
            parameters.Add("@additionalNotes", updateMenuDetailDto.AdditionalNotes);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
