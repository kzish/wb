using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MAspnetUserAvailableTime
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public string Weekday { get; set; }
        public string TimePeriod { get; set; }

        public virtual Aspnetuser AspnetUser { get; set; }
    }
}
