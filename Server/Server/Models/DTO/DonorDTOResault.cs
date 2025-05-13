namespace Server.Models.DTO
{
    public class DonorDTOResault
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public bool? ShowMe { get; set; }
        public List<GiftDTOTheen>? Gifts { get; set; } = new List<GiftDTOTheen>();
    }
}
