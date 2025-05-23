﻿namespace Server.Models.DTO
{
    public class DonorDTOResault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool? ShowMe { get; set; }
        public List<GiftDTOTheen>? Gifts { get; set; } = new List<GiftDTOTheen>();
    }
}
