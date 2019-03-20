using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class Customer : User
    {
        public float _moneyBalance;
        public DateTime _dateOfChange;

        /// <summary>
        /// Creates a new Customer
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="eMailAdress">E-Mail Adress</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="usernumber">Usernumber</param>
        public Customer(string firstName, string lastName, string eMailAdress, string username, string password, int usernumber)
        {
            _username = username;
            _password = new Password(password);
            _usernumber = usernumber;
            _dateOfCreate = DateTime.Now;
            _dateOfChange = DateTime.Now;
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
            _moneyBalance = _moneyBalance + moneyBalance;
            _dateOfChange = DateTime.Now;
        }
    }
}
