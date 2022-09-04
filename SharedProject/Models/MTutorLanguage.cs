using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MTutorLanguage
    {
        public int Id { get; set; }
        public string AspnetUserId { get; set; }
        public int LanguageId { get; set; }
        public int LanguageLevelId { get; set; }

        public virtual Aspnetuser AspnetUser { get; set; }
        public virtual MLanguage Language { get; set; }
        public virtual ELanguageLevel LanguageLevel { get; set; }
    }
}
