﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class User
    {
        public string _firstName, _lastName, _username;
        public int _usernumber;
        public Password _password;
        public DateTime _dateOfCreate;
        public EMailAdress _eMail;

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
        /// <param name="password">Password</param>
        /// <param name="usernumber">Usernumber</param>
        public User (string firstName, string lastName, string eMailAdress, string username, string password, int usernumber)
        {
            _username = username;
            _password = new Password(password);
            _usernumber = usernumber;
            _dateOfCreate = DateTime.Now;
            _eMail = new EMailAdress(eMailAdress);
            _firstName = firstName;
            _lastName = lastName;
        }

        public void updateEmailAdress(string newAdress)
        {
            _eMail.updateEmailAdress(newAdress); 
        }
    }
}
