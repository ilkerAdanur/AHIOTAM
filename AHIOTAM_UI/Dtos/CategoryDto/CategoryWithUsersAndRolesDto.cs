namespace AHIOTAM_UI.Dtos.CategoryDto
{
    public class CategoryWithUsersAndRolesDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryElementId { get; set; }
        public bool CategoryStatus { get; set; }
        public DateTime CategoryCreatedAt { get; set; }
        public int CategoryCreatedId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
