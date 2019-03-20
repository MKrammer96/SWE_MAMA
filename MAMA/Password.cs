using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class Password
    {
        private string phrase = "MAMA_SWE"; // 8 characters

        /// <summary>
        /// Creates a encrypted Password
        /// </summary>
        /// <param name="userinput">Enter Password</param>
        public Password(string userinput)
        {
            Encryption.encrypt(userinput, phrase);
        }

        /// <summary>
        /// Returns the decrypted Password
        /// </summary>
        /// <returns></returns>
        public string getPassword()
        {
            return Encryption.decrypt(phrase);
        }
    }
}
