using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class Password
    {
        static Encryption myEncrypter;

        /// <summary>
        /// Sets a Passwort and stores it encrypted
        /// </summary>
        /// <param name="secretPassword">Choose your password to encrypt</param>
        public static void SetPassword(string secretPassword)
        {
            myEncrypter = new Encryption(secretPassword);
        }

        /// <summary>
        /// Checks your Input
        /// </summary>
        /// <param name="userinput">Userinput</param>
        /// <returns></returns>
        public static bool CheckPassword(string userinput)
        {
            if (myEncrypter.encrpyt(userinput).Equals(myEncrypter.getEncryptedText()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
