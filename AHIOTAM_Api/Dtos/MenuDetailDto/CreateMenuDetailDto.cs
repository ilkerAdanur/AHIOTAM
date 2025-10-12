namespace AHIOTAM_Api.Dtos.MenuDetailDto
{
    public class CreateMenuDetailDto
    {
        public int PreparationTime { get; set; }
        public int Calories { get; set; }
        public string AllergenInfo { get; set; }
        public bool IsSpicy { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
