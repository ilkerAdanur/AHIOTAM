namespace AHIOTAM_UI.Dtos.MenuDto

{
    public class ResultMenuDto
    {
        public int MenuId { get; set; }
        public decimal FoodPrice { get; set; }
        public string FoodTitle { get; set; }
        public string FoodDescription { get; set; }
        public string FoodImageUrl { get; set; }
        public bool SpicealMenu { get; set; }
        public bool MenuStatus { get; set; }
    }
}
