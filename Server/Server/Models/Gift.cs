using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    
    public class Gift
    {
            public int Id { get; set; }
            public int DonorId { get; set; }
            public Donor Donor { get; set; }
            public int CategoryID { get; set; }
            public Category Category { get; set; }
            public string GiftName { get; set; }
            public string? Image { get; set; }
            public string? Details { get; set; }

            [Range(10, 100, ErrorMessage = "The price must be between 10 and 100")]
            public int Price { get; set; }
            public int UserWinnerId { get; set; } = 0;
            public User? Winner { get; set; }
    }
}
