using Microsoft.VisualStudio.TestTools.UnitTesting;
using MAMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA.Tests
{
    [TestClass()]
    public class AddressTests
    {
        [TestMethod()]
        public void GoodAddressTest()
        {
            string street = "Stelzhamerstraße";
            int housenumber = 23;
            string location = "Wels";
            string country = "Austria";
            int postcode = 4600;

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + ", " + country;
            Address myTestAdress = new Address(street, housenumber, postcode, location, country);

            Assert.IsTrue(myTestAdress.getAddress().Equals(shouldBeMyAdress));
        }

        [TestMethod()]
        public void WrongAddressTest1()
        {
            string street = "Stelzhamerstraße";
            int housenumber = 0;
            string location = "Wels";
            string country = "Austria";
            int postcode = 4600;

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + ", " + country;
            Address myTestAdress = new Address(street, housenumber, postcode, location, country);

            Assert.IsFalse(myTestAdress.getAddress().Equals(shouldBeMyAdress));
        }

        [TestMethod()]
        public void WrongAddressTest2()
        {
            string street = "Stelzhamerstraße";
            int housenumber = 23;
            string location = "Wels";
            string country = "Austria";
            int postcode = 46000;

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + ", " + country;
            Address myTestAdress = new Address(street, housenumber, postcode, location, country);

            Assert.IsFalse(myTestAdress.getAddress().Equals(shouldBeMyAdress));
        }

        [TestMethod()]
        public void WrongAddressTest3()
        {
            string street = "1";
            int housenumber = 23;
            string location = "Wels";
            string country = "Austria";
            int postcode = 4600;

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + ", " + country;
            Address myTestAdress = new Address(street, housenumber, postcode, location, country);

            Assert.IsFalse(myTestAdress.getAddress().Equals(shouldBeMyAdress));
        }

        [TestMethod()]
        public void WrongAddressTest4()
        {
            string street = "Stelzhamerstraße";
            int housenumber = 23;
            string location = "0";
            string country = "Austria";
            int postcode = 4600;

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + ", " + country;
            Address myTestAdress = new Address(street, housenumber, postcode, location, country);

            Assert.IsFalse(myTestAdress.getAddress().Equals(shouldBeMyAdress));
        }

        [TestMethod()]
        public void WrongAddressTest5()
        {
            string street = "Stelzhamerstraße";
            int housenumber = 23;
            string location = "Wels";
            string country = "-1";
            int postcode = 4600;

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + ", " + country;
            Address myTestAdress = new Address(street, housenumber, postcode, location, country);

            Assert.IsFalse(myTestAdress.getAddress().Equals(shouldBeMyAdress));
        }
    }
}