﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class Address
    {
        public string _street { get; private set; }
        public int _housenumber { get; private set; }
        public string _location { get; private set; }
        public string _country { get; private set; }
        public int _postcode { get; private set; }

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
            if (street == null)
            {
                // Do nothing
            }
            else if (street.GetType() == typeof (string))
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
            if (location == null)
            {
                // Do nothing
            }
            else if (location.GetType() == typeof(string))
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

            if (country == null)
            {

            }
            else if (country.GetType() == typeof(string))
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
        /// Converts a string into an address. String-Format "street housenumber - postcode location - country"
        /// </summary>
        /// <param name="AddressAsString">Tye in Addres in right format</param>
        /// <returns></returns>
        public static Address ConvertStringToAddress(string AddressAsString)
        {
            string[] splittedAddress = AddressAsString.Split('-');

            string street = string.Empty;
            
            string[] splittedStreet = splittedAddress[0].Split(' ');
            Array.Resize<string>(ref splittedStreet, splittedStreet.Length - 1);

            int housenumber;
            int.TryParse(splittedStreet.Last(), out housenumber);
            // The last index is the housenumber
            for (int i = 0; i < splittedStreet.Length -1; i++)
            {
                street = street + splittedStreet[i] + " ";
            }
            // Remove last " "
            street = street.Remove(street.Length - 1, 1);

            string location = string.Empty;
            string[] splittedLocation = splittedAddress[1].Split(' ');
            // splittedLocation[0] = " "
            Array.Resize<string>(ref splittedLocation, splittedLocation.Length - 1);
            int postcode;
            
            int counter = 0;
            while (!int.TryParse(splittedLocation[counter], out postcode))
            {
                counter++;
                // Try as long, until find postcode
            }

            for (int i = 1+counter; i < splittedLocation.Length; i++)
            {
                location = location + splittedLocation[i] + " ";
            }
            // Remove last " "
            location = location.Remove(location.Length - 1, 1);

            string country = splittedAddress.Last().Remove(0, 1);

            Address returnAddress = new Address(street, housenumber, postcode, location, country);

            return returnAddress;
        }

        /// <summary>
        /// Checks the text, if there are only letters
        /// </summary>
        /// <param name="textToCheck">Text to check</param>
        /// <returns></returns>
        private bool CheckForLetters(string textToCheck)
        {
            string compareString = "ABCDEFGHIJKLMNOPQRSTUVWXYZßÄÖÜ ";

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
        /// Returns the address in Format: street + housenumber - postcode + location - country
        /// </summary>
        /// <returns></returns>
        public string ConvertAdressToString()
        {
            string adress = _street + " " + _housenumber.ToString() + " - " + _postcode.ToString() + " " + _location + " - " + _country;

            return adress;
        }
    }
}
 