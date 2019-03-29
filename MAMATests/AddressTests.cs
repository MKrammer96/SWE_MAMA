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

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + "; " + country;
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

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + "; " + country;
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

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + "; " + country;
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

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + "; " + country;
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

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + "; " + country;
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

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + "; " + country;
            Address myTestAdress = new Address(street, housenumber, postcode, location, country);

            Assert.IsFalse(myTestAdress.getAddress().Equals(shouldBeMyAdress));
        }

        [TestMethod()]
        public void WrongAddressTest6()
        {
            string street = null;
            int housenumber = 0;
            string location = null;
            string country = null;
            int postcode = 0;

            string shouldBeMyAdress = street + " " + housenumber + "; " + postcode + " " + location + "; " + country;
            Address myTestAdress = new Address(street, housenumber, postcode, location, country);

            Assert.IsFalse(myTestAdress.getAddress().Equals(shouldBeMyAdress));
        }

        [TestMethod()]
        public void ConvertStringToAddressTest1()
        {
            string AddressAsString = "Stelzhamerstraße 23; 4600 Wels; Austria";

            Address testAddress = Address.ConvertStringToAddress(AddressAsString);

            string compareString = testAddress.getAddress();

            Assert.AreEqual(AddressAsString, compareString);
        }

        [TestMethod()]
        public void ConvertStringToAddressTest2()
        {
            string AddressAsString = "Bad Schallerbach 1; 1000 Test; Vereinigtes Königreich";

            Address testAddress = Address.ConvertStringToAddress(AddressAsString);

            string compareString = testAddress.getAddress();

            Assert.AreEqual(AddressAsString, compareString);
        }

        [TestMethod()]
        public void ConvertStringToAddressTest3()
        {
            string AddressAsString = "Bad Schallerbach 1; 9999 Ort mit Leerzeichen; Vereinigtes Königreich";

            Address testAddress = Address.ConvertStringToAddress(AddressAsString);

            string compareString = testAddress.getAddress();

            Assert.AreEqual(AddressAsString, compareString);
        }

        [TestMethod()]
        public void ConvertStringToAddressTest4()
        {
            string AddressAsStringBefore = " Straße mit Leerzeichen 1;  9999  Postleitzahl mit Leerzeichen; Vereinigtes Königreich";
            
            // Should be robust against " " before postcode
            string AddressAsString = " Straße mit Leerzeichen 1; 9999  Postleitzahl mit Leerzeichen; Vereinigtes Königreich";

            Address testAddress = Address.ConvertStringToAddress(AddressAsStringBefore);

            string compareString = testAddress.getAddress();

            Assert.AreEqual(AddressAsString, compareString);
        }
    }
}