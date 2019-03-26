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
    public class CustomerTests
    {

        [TestMethod()]
        public void CustomerTest()
        {
            string firstName = "Max";
            string lastName = "Mustermann";
            string eMailAdress = "max.mustermann@students.fh-wels.at";
            int customerNumber = 0;
            int moneyBalance = 42;
            Customer myTestCustomer = new Customer(firstName, lastName, eMailAdress, customerNumber, moneyBalance, DateTime.Now);
            Assert.IsTrue(myTestCustomer._firstName == firstName);
            Assert.IsTrue(myTestCustomer._lastName == lastName);
            Assert.IsTrue(myTestCustomer._customerNumber == customerNumber);
            Assert.IsTrue(myTestCustomer._MoneyBalance == moneyBalance);
        }

        [TestMethod()]
        public void UpdateBalanceTest()
        {
            string firstName = "Max";
            string lastName = "Mustermann";
            string eMailAdress = "max.mustermann@students.fh-wels.at";
            int customerNumber = 0;
            int moneyBalance = 42;
            Customer myTestCustomer = new Customer(firstName, lastName, eMailAdress, customerNumber, moneyBalance, DateTime.Now);

            myTestCustomer.UpdateBalance(0);
            Assert.IsTrue(myTestCustomer._MoneyBalance == 0);
            myTestCustomer.UpdateBalance(-1);
            Assert.IsTrue(myTestCustomer._MoneyBalance == -1);
            myTestCustomer.UpdateBalance(4294967295);
            Assert.IsTrue(myTestCustomer._MoneyBalance == 4294967295);
            myTestCustomer.UpdateBalance(4294967296);
            Assert.IsTrue(myTestCustomer._MoneyBalance == 4294967296);
            myTestCustomer.UpdateBalance(-4294967296);
            Assert.IsTrue(myTestCustomer._MoneyBalance == -4294967296);
        }

        [TestMethod()]
        public void UpdateNameEmailTest()
        {
            string firstName = "Max";
            string lastName = "Mustermann";
            string eMailAdress = "max.mustermann@students.fh-wels.at";
            int customerNumber = 0;
            int moneyBalance = 42;
            Customer myTestCustomer = new Customer(firstName, lastName, eMailAdress, customerNumber, moneyBalance, DateTime.Now);

            string eMailAdressNew = "max.mustermann@students.fh-wels.at";
            myTestCustomer.updateEmailAdress(eMailAdressNew);
            Assert.IsTrue(myTestCustomer._eMail.getEmailAdress().Equals(eMailAdressNew));
        }
    }
}