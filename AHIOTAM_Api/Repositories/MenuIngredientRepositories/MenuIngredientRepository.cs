using AHIOTAM_Api.Dtos.MenuIngredientDto;
using AHIOTAM_Api.Models.Context;
using Dapper;

namespace AHIOTAM_Api.Repositories.MenuIngredientRepositories
{
    public class MenuIngredientRepository: IMenuIngredientRepository
    {
        private readonly Context _context;
        public MenuIngredientRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateMenuIngredient(CreateMenuIngredientDto createMenuIngredientDto)
        {
            string query = "INSERT INTO MenuIngredient (MenuDetailId, IngredientName, Quantity) VALUES (@menuDetailId, @ingredientName, @quantity)";
            var parameters = new DynamicParameters();
            parameters.Add("@menuDetailId", createMenuIngredientDto.MenuDetailId);
            parameters.Add("@ingredientName", createMenuIngredientDto.IngredientName);
            parameters.Add("@quantity", createMenuIngredientDto.Quantity);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteMenuIngredient(int id)
        {
            string query = "DELETE FROM MenuIngredient WHERE MenuIngredientId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<List<ResultMenuIngredientDto>> GetAllMenuIngredient()
        {
            string query = "SELECT * FROM MenuIngredient";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultMenuIngredientDto>(query);
                return result.ToList();
            }
        }
        public async Task<GetByIdMenuIngredientDto> GetMenuIngredientById(int id)
        {
            string query = "SELECT * FROM MenuIngredient WHERE MenuIngredientId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<GetByIdMenuIngredientDto>(query, parameters);
                return result;
            }
        }
        public async Task UpdateMenuIngredient(UpdateMenuIngredientDto updateMenuIngredientDto)
        {
            string query = "UPDATE MenuIngredient SET MenuDetailId = @menuDetailId, IngredientName = @ingredientName, Quantity = @quantity WHERE MenuIngredientId = @menuIngredientId";
            var parameters = new DynamicParameters();
            parameters.Add("@menuDetailId", updateMenuIngredientDto.MenuDetailId);
            parameters.Add("@ingredientName", updateMenuIngredientDto.IngredientName);
            parameters.Add("@quantity", updateMenuIngredientDto.Quantity);
            parameters.Add("@menuIngredientId", updateMenuIngredientDto.MenuIngredientId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
