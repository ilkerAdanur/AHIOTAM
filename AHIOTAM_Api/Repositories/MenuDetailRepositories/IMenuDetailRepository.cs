using AHIOTAM_Api.Dtos.MenuDetailDto;

namespace AHIOTAM_Api.Repositories.MenuDetailRepositories
{
    public interface IMenuDetailRepository
    {
        Task<List<ResultMenuDetailDto>> GetAllMenuDetail();
        Task<GetByIdMenuDetailDto> GetMenuDetailById(int id);
        Task CreateMenuDetail(CreateMenuDetailDto createMenuDetailDto);
        Task UpdateMenuDetail(UpdateMenuDetailDto updateMenuDetailrDto);
        Task DeleteMenuDetail(int id);
    }
}
