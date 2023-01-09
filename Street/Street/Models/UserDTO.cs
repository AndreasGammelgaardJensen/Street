﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Street.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Posts { get; set; }
    }
}
