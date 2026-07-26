using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Infrastructure.Entities
{
    public class UserEntity
    {
        public int Id{get; set;}
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public required string Email { get; set; }
    }
}
