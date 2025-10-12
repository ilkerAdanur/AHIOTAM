namespace AHIOTAM_Api.Dtos.GalleryDto
{
    public class GetByIdGalleryDto
    {
        public int GalleryId { get; set; }
        public string Description { get; set; }
        public string FoodImageUrl { get; set; }
        public bool GalleryStatus { get; set; }

    }
}
