namespace Server.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int GiftId { get; set; }
        public Gift Gift { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public bool isWin { get; set; } = false;
        public bool isPaid { get; set; } = false;
    }
}
