using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class Customer : User
    {
        public float MoneyBalance;
        public DateTime DateOfChange;


        /// <summary>
        /// Creates a new Customer
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="eMailAdress">E-Mail Adress</param>
        /// <param name="customerNumber">Usernumber</param>
        public Customer(string firstName, string lastName, string eMailAdress, int customerNumber, float moneyBalance)
        {
            MoneyBalance = moneyBalance;
            _customerNumber = customerNumber;
            _dateOfCreate = DateTime.Now;
            DateOfChange = DateTime.Now;
            _eMail = new EMailAdress(eMailAdress);
            _firstName = firstName;
            _lastName = lastName;
        }

        //public Customer()
        //{

        //}

        /// <summary>
        /// Updates the Balance of the user
        /// </summary>
        /// <param name="moneyBalance">Put in Money</param>
        public void UpdateBalance(int moneyBalance)
        {
            MoneyBalance = MoneyBalance + moneyBalance;
            DateOfChange = DateTime.Now;
        }
    }
}
