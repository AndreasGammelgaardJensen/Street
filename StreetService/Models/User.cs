﻿using System.ComponentModel.DataAnnotations;

namespace StreetService.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]

        public string Name {get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Posts { get; set; }

        public List<Group> Groups { get; set; }

    }
}