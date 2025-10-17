namespace AHIOTAM_UI.Dtos.MenuDetailDto
{
    public class ResultMenuWithDetailDto
    {
        public int MenuId { get; set; }
        public decimal FoodPrice { get; set; }
        public string FoodTitle { get; set; }
        public string FoodDescription { get; set; }
        public string FoodImageUrl { get; set; }
        public bool SpicealMenu { get; set; } // Not: Bu muhtemelen 'SpecialMenu' olmalı, veritabanına göre düzeltin.
        public bool MenuStatus { get; set; }
        public int PreparationTime { get; set; }
        public int Calories { get; set; }
        public string AllergenInfo { get; set; }
        public bool IsSpicy { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
