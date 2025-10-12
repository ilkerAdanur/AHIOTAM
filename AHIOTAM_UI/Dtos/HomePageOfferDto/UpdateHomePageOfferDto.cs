namespace AHIOTAM_UI.Dtos.HomePageOfferDto
{
    public class UpdateHomePageOfferDto
    {
        public int OfferId { get; set; }
        public decimal FoodPrice { get; set; }
        public string FoodTitle { get; set; }
        public string FoodDescription { get; set; }
        public string FoodImageUrl { get; set; }
        public bool SpicealMenu { get; set; }
        public bool MenuStatus { get; set; }
    }
}
