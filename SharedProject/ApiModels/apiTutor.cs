using Nest;
using System;
using System.Collections.Generic;

namespace Globals
{
    //[ElasticsearchType]
    [ElasticsearchType(RelationName = "apiTutor", IdProperty = "AspnetUserId")]
    public class apiTutor
    {
        [Keyword]
        public string AspnetUserId { get; set; }
        [Keyword]
        public string Firstname { get; set; }
        [Keyword]
        public string Surname { get; set; }
        [Keyword]
        public string Email { get; set; }
        [Keyword]
        public string ImageUrl { get; set; }
        [Keyword]
        public string CoutryIso { get; set; }
        [Keyword]
        public string CoutryName { get; set; }
        [Text]
        public string About { get; set; }
        [Object]
        public List<Language> Languages { get; set; } = new List<Language>();
        [Object]
        public List<Course> Courses { get; set; } = new List<Course>();
        [Object]
        public List<AvailableTimes> AvailableTimes { get; set; } = new List<AvailableTimes>();
        [Keyword]
        public string Mobile { get; set; }
        [Keyword]
        public string OtherMobile { get; set; }
        //[Boolean(NullValue = false, Store = true)]
        public sbyte MobileAvailableOnWhatsapp { get; set; }
        //[Boolean(NullValue = false, Store = true)]
        public sbyte ShowEmail { get; set; }
        public sbyte Active { get; set; }
    }

    public class Language
    {
        [Keyword]
        public int level { get; set; }
        [Keyword]
        public string lang { get; set; }

    }

    public partial class Course
    {
        [Text]
        public string Title { get; set; }
        [Text]
        public string Description { get; set; }
        [Keyword]
        public string Duration { get; set; }
    }

    public partial class AvailableTimes
    {
        [Keyword]
        public string Weekday { get; set; }
        [Keyword]
        public string TimePeriod { get; set; }

    }

}
