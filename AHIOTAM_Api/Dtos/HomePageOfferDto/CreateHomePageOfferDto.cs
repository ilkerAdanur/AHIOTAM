namespace AHIOTAM_Api.Dtos.HomePageOfferDto
{
    public class CreateHomePageOfferDto
    {
        public decimal FoodPrice { get; set; }
        public string FoodTitle { get; set; }
        public string FoodDescription { get; set; }
        public string FoodImageUrl { get; set; }
        public bool SpicealMenu { get; set; }
        public bool MenuStatus { get; set; }
    }
}
