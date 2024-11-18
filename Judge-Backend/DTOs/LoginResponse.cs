using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judge_Backend.DTOs
{
    public class LoginResponse
    {
        public int UserID { get; set; }
        public string Username { get; set; } = default!;
        public string Role { get; set; } = default!;
    }
}