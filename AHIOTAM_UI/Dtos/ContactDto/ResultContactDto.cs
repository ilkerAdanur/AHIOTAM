namespace AHIOTAM_UI.Dtos.ContactDto

{
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

    }
}
