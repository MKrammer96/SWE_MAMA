using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class User
    {
        public string _firstName, _lastName, _username;
        public int _customerNumber;
        public Password _password;
        public DateTime _dateOfCreate;
        public EMailAddress _eMail;

        public User()
        {

        }

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="eMailAdress">E-Mail Adress</param>
        /// <param name="username">Username</param>
        /// <param name="customerNumber">Usernumber</param>
        public User (string firstName, string lastName, string eMailAdress, string username, int customerNumber)
        {
            _username = username;
            _customerNumber = customerNumber;
            _dateOfCreate = DateTime.Now;
            _eMail = new EMailAddress(eMailAdress);
            _firstName = firstName;
            _lastName = lastName;
        }

        public void updateEmailAdress(string newAdress)
        {
            _eMail.updateEmailAddress(newAdress); 
        }
    }
}
