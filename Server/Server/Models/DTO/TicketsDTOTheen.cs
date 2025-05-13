namespace Server.Models.DTO
{
    public class TicketsDTOTheen
    {
        public int Id { get; set; }
        public UserDTOTheen User { get; set; }
        public DateTime OrderDate { get; set; }
        public bool isWin { get; set; } = false;
        public bool isPaid { get; set; } = false;
    }
}
