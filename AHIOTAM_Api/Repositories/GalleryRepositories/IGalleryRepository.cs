using AHIOTAM_Api.Dtos.GalleryDto;

namespace AHIOTAM_Api.Repositories.GalleryRepositories
{
    public interface IGalleryRepository
    {
        Task<List<ResultGalleryDto>> GetAllGallery();
        Task<List<ResultGalleryDto>> GetGalleriesWithActiveStatus();
        Task CreateGallery(CreateGalleryDto createGalleryDto);
        Task DeleteGallery(int id);
        Task ToggleGalleryStatus(int id);
    }
}
