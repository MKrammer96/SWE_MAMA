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
        /// <param name="eMailAddress">E-Mail Address</param>
        /// <param name="customerNumber">Usernumber</param>
        /// <param name="moneyBalance">Money Balance</param>
        /// <param name="DateOfChange">Date of change</param>
        public Customer(string firstName, string lastName, string eMailAddress, int customerNumber, float moneyBalance, DateTime DateOfChange)
        {
            _MoneyBalance = moneyBalance;
            _customerNumber = customerNumber;
            _dateOfCreate = DateTime.Now;
            _DateOfChange = DateOfChange;
            _eMail = new EMailAddress(eMailAddress);
            _firstName = firstName;
            _lastName = lastName;
        }

        /// <summary>
        /// New Constructor with address info
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="eMailAddress">E-Mail Address</param>
        /// <param name="customerNumber">Usernumber</param>
        /// <param name="moneyBalance">Money Balance</param>
        /// <param name="DateOfChange">Date of change</param>
        /// <param name="address">address</param>
        public Customer(string firstName, string lastName, EMailAddress eMailAddress, int customerNumber, float moneyBalance, DateTime DateOfChange, Address address)
        {
            _MoneyBalance = moneyBalance;
            _customerNumber = customerNumber;
            _dateOfCreate = DateTime.Now;
            _DateOfChange = DateOfChange;
            _eMail = eMailAddress;
            _firstName = firstName;
            _lastName = lastName;
            _adress = address;
        }

        /// <summary>
        /// Adds a Adress to a customer
        /// </summary>
        /// <param name="street">Street</param>
        /// <param name="housenumber">housenumber</param>
        /// <param name="postcode">postcode</param>
        /// <param name="location">location</param>
        /// <param name="country">country</param>
        public void AddAddressToCustomer(string street, int housenumber, int postcode, string location, string country)
        {
            _adress = new Address(street, housenumber, postcode, location, country);
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
        /// Updates the E-Mail Address
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="e_MailAddress"></param>
        public void UpdateNameAddressEmail(string lastname, EMailAddress e_MailAddress, Address address)
        {
            if (address != null)
            {
                _adress = address;
            }            
            _lastName = lastname;
            _eMail = e_MailAddress;
        }
    }
}
