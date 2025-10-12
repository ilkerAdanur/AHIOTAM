using AHIOTAM_Api.Dtos.GalleryDto;
using AHIOTAM_Api.Repositories.GalleryRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        private readonly IGalleryRepository _galleryRepository;
        public GalleriesController(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGallery()
        {
            var values = await _galleryRepository.GetAllGallery();
            return Ok(values);
        }
        [HttpGet("GetGalleriesWithActiveStatus")]
        public async Task<IActionResult> GetGalleriesWithActiveStatus()
        {
            var values = await _galleryRepository.GetGalleriesWithActiveStatus();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGallery([FromForm] CreateGalleryDto dto)
        {
            // Artık dosya API'ye kaydedilmeyecek
            await _galleryRepository.CreateGallery(dto);
            return Ok("Görsel başarılı şekilde eklendi.");
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateGallery([FromForm] CreateGalleryDto createGalleryDto)
        //{
        //    if (createGalleryDto.ImageFile == null || createGalleryDto.ImageFile.Length == 0)
        //        return BadRequest("Bir görsel dosyası yüklenmedi.");

        //    // Kayıt klasörü
        //    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/eatwell/images");
        //    if (!Directory.Exists(uploadsFolder))
        //        Directory.CreateDirectory(uploadsFolder);

        //    // Benzersiz isim
        //    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(createGalleryDto.ImageFile.FileName);
        //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //    // Dosyayı kaydet
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await createGalleryDto.ImageFile.CopyToAsync(stream);
        //    }

        //    // Görsel yolunu ayarla (veritabanı için)
        //    createGalleryDto.FoodImageUrl = "/eatwell/images/" + uniqueFileName;

        //    // Veritabanına kaydet
        //    await _galleryRepository.CreateGallery(createGalleryDto);

        //    return Ok("Görsel başarıyla eklendi.");
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallery(int id)
        {
            await _galleryRepository.DeleteGallery(id);
            return Ok(id);
        }
        [HttpPost("ToggleGalleryStatus/{id}")]
        public async Task<IActionResult> ToggleGalleryStatus(int id)
        {
            await _galleryRepository.ToggleGalleryStatus(id);
            return Ok();
        }

    }
}
