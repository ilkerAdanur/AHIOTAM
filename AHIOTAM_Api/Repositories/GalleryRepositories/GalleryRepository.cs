using AHIOTAM_Api.Dtos.GalleryDto;
using AHIOTAM_Api.Models.Context;
using Dapper;

namespace AHIOTAM_Api.Repositories.GalleryRepositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly Context _context;

        public GalleryRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultGalleryDto>> GetAllGallery()
        {
            string query = "SELECT * FROM Gallery";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<ResultGalleryDto>(query);
                return value.ToList();
            }
        }
        public async Task CreateGallery(CreateGalleryDto createGalleryDto)
        {
            string query = "INSERT INTO Gallery (Description, FoodImageUrl,GalleryStatus) VALUES (@description,@foodImageUrl,@galleryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@description", createGalleryDto.Description);
            parameters.Add("@foodImageUrl", createGalleryDto.FoodImageUrl);
            parameters.Add("@galleryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task DeleteGallery(int id)
        {
            string query = "Delete from Gallery where GalleryId = @galleryId";
            var parameters = new DynamicParameters();
            parameters.Add("@galleryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultGalleryDto>> GetGalleriesWithActiveStatus()
        {
            string query = "SELECT * FROM Gallery where GalleryStatus = 1";
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<ResultGalleryDto>(query);
                return value.ToList();
            }
        }

        public async Task ToggleGalleryStatus(int id)
        {
            string query = "Update Gallery set GalleryStatus = CASE WHEN GalleryStatus = 1 THEN 0 ELSE 1 END where GalleryId = @galleryId";
            var parameters = new DynamicParameters();
            parameters.Add("@galleryId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
