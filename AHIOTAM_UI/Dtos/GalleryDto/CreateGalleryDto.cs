using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.Dtos.GalleryDto
{
    public class CreateGalleryDto
    {
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
        public bool GalleryStatus { get; set; }
    }
}
