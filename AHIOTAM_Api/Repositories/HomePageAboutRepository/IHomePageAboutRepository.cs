using AHIOTAM_Api.Dtos.HomePageAboutDto;

namespace AHIOTAM_Api.Repositories.HomePageAboutRepository
{
    public interface IHomePageAboutRepository
    {
        Task<List<ResultHomePageAboutDto>> GetAllAboutAsync();
        Task<GetByIdHomePageAboutDto> GetAboutByIdAsync(int id);
        Task CreateAboutAsync(CreateHomePageAboutDto createDto);
        Task UpdateAboutAsync(UpdateHomePageAboutDto updateDto);
        Task DeleteAboutAsync(int id);
    }
}
