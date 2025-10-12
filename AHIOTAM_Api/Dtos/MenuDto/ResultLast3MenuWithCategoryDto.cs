namespace AHIOTAM_Api.Dtos.MenuDto
{
    public class ResultLast3MenuWithCategoryDto
    {
        public int MenuId { get; set; }
        public decimal FoodPrice { get; set; }
        public string FoodTitle { get; set; }
        public string FoodDescription { get; set; }
        public string FoodImageUrl { get; set; }
        public int MenuCategoryId { get; set; }
        public bool SpicealMenu { get; set; }
        public bool MenuStatus { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public string CategoryElementId { get; set; }
    }
}
