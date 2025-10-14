using AHIOTAM_Api.Dtos.CategoryDto;
using AHIOTAM_Api.Models.Context;
using Dapper;
using System.Text.RegularExpressions;

namespace AHIOTAM_Api.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }
        private string GenerateCategoryElementId(string categoryName)
        {
            // Türkçe karakterleri İngilizce karşılıklarına çevir
            string normalized = categoryName
                .ToLower()
                .Replace("ç", "c")
                .Replace("ğ", "g")
                .Replace("ı", "i")
                .Replace("ö", "o")
                .Replace("ş", "s")
                .Replace("ü", "u")
                .Replace(" ", ""); // boşlukları kaldır

            // Gerekirse özel karakterleri de temizle
            normalized = Regex.Replace(normalized, @"[^a-z0-9]", ""); // sadece küçük harf ve rakam kalsın

            return normalized;
        }

        public async Task<List<ResultCategoryDto>> GetAllCategory()
        {
            string query = "Select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }
        public async Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var elementId = GenerateCategoryElementId(createCategoryDto.CategoryName);
            string query = "INSERT INTO Category (CategoryName, CategoryStatus,CategoryElementId,CategoryCreatedAt,CategoryCreatedId) VALUES (@categoryName, @categoryStatus,@categoryElementId,@categoryCreatedAt,@categoryCreatedId)";
            var parameters = new DynamicParameters();

            parameters.Add("@categoryName", createCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);
            parameters.Add("@categoryElementId", elementId);
            parameters.Add("@categoryCreatedAt", DateTime.UtcNow);
            parameters.Add("@categoryCreatedId", createCategoryDto.CategoryCreatedId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task<GetByIdCategoryDto> GetCategoryById(int id)
        {
            string query = "Select * from Category where CategoryId = @categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var elementId = GenerateCategoryElementId(updateCategoryDto.CategoryName);
            string query = "UPDATE Category SET CategoryName = @categoryName, CategoryStatus = @categoryStatus, CategoryElementId = @categoryElementId WHERE CategoryId = @categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", updateCategoryDto.CategoryName);
            parameters.Add("@categoryStatus", updateCategoryDto.CategoryStatus);
            parameters.Add("@categoryId", updateCategoryDto.CategoryId);
            parameters.Add("@categoryCreatedId", updateCategoryDto.CategoryCreatedId);
            parameters.Add("@categoryElementId", elementId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCategory(int id)
        {
            string query = "Delete from Category where CategoryId = @categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ToggleCategoryStatus(int id)
        {
            string query = "UPDATE Category SET CategoryStatus = CASE WHEN CategoryStatus = 1 THEN 0 ELSE 1 END WHERE CategoryId = @categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
