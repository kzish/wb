using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
