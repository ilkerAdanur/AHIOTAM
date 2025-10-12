namespace AHIOTAM_Api.Dtos.MenuIngredientDto
{
    public class GetByIdMenuIngredientDto
    {
        public int MenuIngredientId { get; set; }
        public int MenuDetailId { get; set; }
        public string IngredientName { get; set; }
        public string Quantity { get; set; }
    }
}
