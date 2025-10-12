using AHIOTAM_Api.Dtos.ContactDto;

namespace AHIOTAM_Api.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContact();
        Task<GetByIdContactDto> GetContactById(int id);
        Task CreateContact(CreateContactDto createContactDto);
        Task UpdateContact(UpdateContactDto updateContactrDto);
        Task DeleteContact(int id);
        Task<ResultContactDto> GetActiveContact();
        Task SetActiveContact(int id);
    }
}
