﻿namespace Server.Models.DTO
{
    public class UserDTOTheen
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public UserRole Role { get; set; } = UserRole.User;

    }
}
