using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Country
    {
        #region Fields and Properties
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; } = true;
        #endregion

        #region Constructors
        public Country()
        {

        }
        public Country(int id, string countryCode, string countryName)
        {
            this.CountryId = id;
            this.CountryCode = countryCode;
            this.CountryName = countryName;
        }
        #endregion

        public IList<Country> GetCountry()
        {
            var AllCountries = new List<Country>
            {
                new Country(1, "SRB", "Serbia")
            };
            return AllCountries;
        }
    }
}
