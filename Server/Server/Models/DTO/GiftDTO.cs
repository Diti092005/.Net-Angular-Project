namespace Server.Models.DTO
{
    public class GiftDTO
    {
        public int DonorId { get; set; }
        public int CategoryId{ get; set; }
        public string GiftName { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
        public int? WinnerId { get; set; }
    }
}
