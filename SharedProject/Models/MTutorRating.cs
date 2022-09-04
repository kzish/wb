using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MTutorRating
    {
        public int Id { get; set; }
        public string TutorAspnetIdFk { get; set; }
        public int? FiveStarRating { get; set; }
        public int? FourStarRating { get; set; }
        public int? ThreeStarRating { get; set; }
        public int? TwoStarRating { get; set; }
        public int? OneStarRating { get; set; }
        public string RatorsIdNfk { get; set; }

        public virtual Aspnetuser TutorAspnetIdFkNavigation { get; set; }
    }
}
