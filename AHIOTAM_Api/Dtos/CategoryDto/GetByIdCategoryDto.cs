namespace AHIOTAM_Api.Dtos.CategoryDto
{
    public class GetByIdCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryElementId { get; set; }
        public bool CategoryStatus { get; set; }
        public DateTime CategoryCreatedAt { get; set; }
        public int CategoryCreatedId { get; set; }
    }
}
