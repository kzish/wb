using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MMoodleUser
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public int? MoodleId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual Aspnetuser AspnetUser { get; set; }
    }
}
