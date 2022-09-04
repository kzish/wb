using System;
using System.Collections.Generic;

#nullable disable

namespace SharedModels
{
    public partial class MCountry
    {
        public string CountryIso { get; set; }
        public string CountryIso3 { get; set; }
        public int CallingCode { get; set; }
        public string CountryName { get; set; }
        public string Value { get; set; }
    }
}
