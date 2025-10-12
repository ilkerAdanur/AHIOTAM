using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Dtos.GalleryDto
{
    public class CreateGalleryDto
    {
        public string? Description { get; set; }

        public string? FoodImageUrl { get; set; } // bu alan API'de dolacak

        public bool GalleryStatus { get; set; }

        [FromForm] // Bu önemli! Aşağıdaki alan formdan dosya olarak alınacak
        public IFormFile? ImageFile { get; set; }
    }
}
