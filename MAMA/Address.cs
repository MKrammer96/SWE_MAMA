using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    class Address
    {
        private string _street = string.Empty;
        private int _houseNumber = 0;
        private string _location = string.Empty;
        private string _country = string.Empty;
        private int _postcode = 0;

        /// <summary>
        /// Creates a new address
        /// </summary>
        /// <param name="street">street</param>
        /// <param name="housenumber">housenumber</param>
        /// <param name="postcode">postcode</param>
        /// <param name="location">location</param>
        /// <param name="country">country</param>
        public Address(string street, int housenumber, int postcode, string location, string country)
        {
            if (street.GetType() == typeof (string))
            {
                _street = street;
            }
            else
            {
                _street = "No valid street";
            }

            if (housenumber.GetType() == typeof(int))
            {
                _houseNumber = housenumber;
            }
            else
            {
                _houseNumber = -1;
            }

            if (postcode.GetType() == typeof(int))
            {
                _postcode = postcode;
            }
            else
            {
                _postcode = -1;
            }
            
            if (location.GetType() == typeof(string))
            {
                _location = location;
            }
            else
            {
                _location = "No valid location";
            }

            if (country.GetType() == typeof(string))
            {
                _country = country;
            }
            else
            {
                _country = "No vald country";
            }
        }

        /// <summary>
        /// Returns the address in Format: street + housenumber; postcode + location; country
        /// </summary>
        /// <returns></returns>
        public string getAddress()
        {
            string adress = _street + " " + _houseNumber + "; " + _postcode + " " + _location + ", " + _country;

            return adress;
        }
    }
}
 