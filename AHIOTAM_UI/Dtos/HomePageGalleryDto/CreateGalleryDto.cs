using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_UI.Dtos.HomePageGalleryDto
{
    public class CreateGalleryDto
    {
        public string Description { get; set; }
        public string FoodImageUrl { get; set; }
        public bool GalleryStatus { get; set; }
        [FromForm] // Bu önemli! Aşağıdaki alan formdan dosya olarak alınacak
        public IFormFile? ImageFile { get; set; }
    }
}
