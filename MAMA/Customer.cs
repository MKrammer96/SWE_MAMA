using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class Customer : User
    {
        public float _MoneyBalance;
        public DateTime _DateOfChange;


        /// <summary>
        /// Creates a new Customer
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="eMailAdress">E-Mail Adress</param>
        /// <param name="customerNumber">Usernumber</param>
        public Customer(string firstName, string lastName, string eMailAdress, int customerNumber, float moneyBalance, DateTime DateOfChange)
        {
            _MoneyBalance = moneyBalance;
            _customerNumber = customerNumber;
            _dateOfCreate = DateTime.Now;
            _DateOfChange = DateOfChange;
            _eMail = new EMailAdress(eMailAdress);
            _firstName = firstName;
            _lastName = lastName;
        }

        /// <summary>
        /// Adds moneyBalance to the actual Balance
        /// </summary>
        /// <param name="moneyBalance">Put in Money</param>
        public void UpdateBalance(float moneyBalance)
        {
            _MoneyBalance = moneyBalance;
            _DateOfChange = DateTime.Now;
        }

        /// <summary>
        /// Updates the E-Mail Adress
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="e_MailAddress"></param>
        public void UpdateNameEmail(string lastname, EMailAdress e_MailAddress)
        {
            _lastName = lastname;
            _eMail = e_MailAddress;
        }
    }
}
