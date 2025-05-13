namespace Server.Models.DTO
{
    public class GiftDTOTheen
    {
        public int Id { get; set; }
        public string GiftName { get; set; }
        public string? Details { get; set; }
        public int Price { get; set; } = 10;
        public string? Image { get; set; }
        public UserDTOTheen? Winner { get; set; } 
    }
}
