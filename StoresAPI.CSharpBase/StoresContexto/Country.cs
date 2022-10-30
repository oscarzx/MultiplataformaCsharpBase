using System;
using System.Collections.Generic;

namespace StoresAPI.CSharpBase.StoresContexto
{
    public partial class Country
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; } = null!;
        public string Name { get; set; } = null!;

        public Country()
        {

        }

        public Country(int countryId, string countryCode, string name)
        {
            CountryId = countryId;
            CountryCode = countryCode;
            Name = name;
        }
    }
}
