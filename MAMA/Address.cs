using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class Address
    {
        private string _street = string.Empty;
        private int _housenumber = 0;
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
                if (CheckForLetters(street))
                {
                    _street = street;
                }
                else
                {
                    _street = "No valid street";
                }
            }
            else
            {
                _street = "No valid street";
            }

            if (housenumber.GetType() == typeof(int))
            {
                if (housenumber > 0)
                {
                    _housenumber = housenumber;
                }
                else
                {
                    _housenumber = -1;
                }
            }
            else
            {
                _housenumber = -1;
            }

            if (postcode.GetType() == typeof(int))
            {
                if (postcode > 999 && postcode < 10000)
                {
                    _postcode = postcode;
                }
                else
                {
                    _postcode = -1;
                }
            }
            else
            {
                _postcode = -1;
            }
            
            if (location.GetType() == typeof(string))
            {
                if (CheckForLetters(location))
                {
                    _location = location;
                }
                else
                {
                    _location = "No valid location";
                }
            }
            else
            {
                _location = "No valid location";
            }

            if (country.GetType() == typeof(string))
            {
                if (CheckForLetters(country))
                {
                    _country = country;
                }
                else
                {
                    _country = "No vald country";
                }
            }
            else
            {
                _country = "No vald country";
            }
        }

        /// <summary>
        /// Checks the text, if there are only letters
        /// </summary>
        /// <param name="textToCheck">Text to check</param>
        /// <returns></returns>
        private bool CheckForLetters(string textToCheck)
        {
            string compareString = "ABCDEFGHIJKLMNOPQRSTUVWXYZß";

            foreach (char ch in textToCheck)
            {
                if (!compareString.Contains(char.ToUpper(ch)))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns the address in Format: street + housenumber; postcode + location; country
        /// </summary>
        /// <returns></returns>
        public string getAddress()
        {
            string adress = _street + " " + _housenumber + "; " + _postcode + " " + _location + ", " + _country;

            return adress;
        }
    }
}
 