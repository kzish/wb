using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MTutorCourse
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public int? MoodleCourseId { get; set; }

        public virtual Aspnetuser AspnetUser { get; set; }
    }
}
