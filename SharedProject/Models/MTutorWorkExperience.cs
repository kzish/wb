using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MTutorWorkExperience
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Organization { get; set; }
        public string PositionHeld { get; set; }
        public string Roles { get; set; }

        public virtual Aspnetuser AspnetUser { get; set; }
    }
}
