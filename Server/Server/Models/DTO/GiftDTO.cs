namespace Server.Models.DTO
{
    public class GiftDTO
    {
        public int DonorId { get; set; }
        public int CategoryID { get; set; }
        public string GiftName { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
    }
}
