using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class ETimePeriod
    {
        public string Id { get; set; }
        public string TimePeriod { get; set; }
        public string Title { get; set; }
        public int? Sequence { get; set; }
    }
}
