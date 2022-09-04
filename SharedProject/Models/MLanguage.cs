using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MLanguage
    {
        public MLanguage()
        {
            MAspnetUserLanguages = new HashSet<MAspnetUserLanguage>();
        }

        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string Iso { get; set; }
        public string Value { get; set; }

        public virtual ICollection<MAspnetUserLanguage> MAspnetUserLanguages { get; set; }
    }
}
