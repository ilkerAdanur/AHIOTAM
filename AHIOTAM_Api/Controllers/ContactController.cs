using AHIOTAM_Api.Dtos.ContactDto;
using AHIOTAM_Api.Repositories.ContactRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository ContactRepository)
        {
            _contactRepository = ContactRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContact()
        {
            var values = await _contactRepository.GetAllContact();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var values = await _contactRepository.GetContactById(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactRepository.CreateContact(createContactDto);
            return Ok("Kontak kısmı başarılı şekilde yüklendi : " + createContactDto.ToString());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactRepository.UpdateContact(updateContactDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
            return Ok();
        }
        [HttpGet("GetActiveContact")]
        public async Task<IActionResult> GetActiveContact()
        {
            var values = await _contactRepository.GetActiveContact();
            return Ok(values);
        }
        [HttpPost("SetActiveContact/{id}")]
        public async Task<IActionResult> SetActiveContact(int id)
        {
            await _contactRepository.SetActiveContact(id);
            return Ok();
        }
    }
}
