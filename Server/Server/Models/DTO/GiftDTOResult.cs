namespace Server.Models.DTO
{
    public class GiftDTOResualt
    {
        public int Id { get; set; }
        public string GiftName { get; set; }
        public string? Details { get; set; }
        public int Price { get; set; } = 10;
        public int Size { get; set; } = 1;
        public string? Image { get; set; }
        public int? UserWinnerId { get; set; } = 0;
        public Category Category { get; set; }

    }
}
