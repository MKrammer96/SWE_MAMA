using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class EMailAddress
    {
        public string Address { get; private set; }

        /// <summary>
        /// Creates a new E-Mail Address and checks, if it is correct / (empty string, if false)
        /// </summary>
        /// <param name="address">Address</param>
        public EMailAddress(string address)
        {
            if (verifyEmailAddress(address))
            {
                Address = address;
            }
            else
            {
                Address = "";
            }
        }

        /// <summary>
        /// Updates your EMail-Address / (empty string, if false)
        /// </summary>
        /// <param name="address">e-Mail Address</param>
        public void updateEmailAddress(string address)
        {
            if (verifyEmailAddress(address))
            {
                Address = address;
            }
            else
            {
                Address = "";
            }
        }

        /// <summary>
        /// Returns your EMail-Address
        /// </summary>
        /// <returns></returns>
        public string getEmailAddress()
        {
            return Address;
        }

        /// <summary>
        /// Checks your EMail-Address / (empty string, if false)
        /// </summary>
        /// <param name="eMailAddress"></param>
        /// <returns></returns>
        public bool verifyEmailAddress(string eMailAddress)
        {
            bool cond0, cond1, cond2, cond3;
            cond0 = false;
            cond1 = false;
            cond2 = false;
            cond3 = false;

            cond0 = checkIfString(eMailAddress);

            // Check @
            if (cond0)
            {
                cond1 = checkAt(eMailAddress);
            }

            if (cond1)
            {
                string[] splitAddress = eMailAddress.Split('@');
                if (splitAddress[0] == string.Empty || splitAddress[1] == string.Empty)
                {
                    return false;
                }
                else
                {
                    cond2 = checkAfterAT(splitAddress[1]);
                    cond3 = checkBeforeAT(splitAddress[0]);
                }
            }

            if (cond0 && cond1 && cond2 && cond3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkIfString(string eMailAddress)
        {
            // Check last Condition
            if (eMailAddress == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkBeforeAT(string beforeAt)
        {
            // Check if before @ is letter
            if (!char.IsLetter(beforeAt.Last()))
            {
                return false;
            }

            // Check if before @ is no .
            if (beforeAt.Last() == '.')
            {
                return false;
            }

            // Check if at the end is no .
            if (beforeAt.First() == '.')
            {
                return false;
            }


            // Everything fine
            return true;
        }

        private bool checkAfterAT(string afterAt)
        {
            // Check if ther is no . directly after @
            if (afterAt[0] == '.')
            {
                return false;
            }

            // Check if ther is no . at the end
            if (afterAt.Last() == '.')
            {
                return false;
            }


            // Check if only at least one . after @
            if (afterAt.Contains('.'))
            {
                string[] finalParts = afterAt.Split('.');
                string finalPart = finalParts.Last();

                // Check if
                foreach (char letter in finalPart)
                {
                    if (char.IsDigit(letter))
                    {
                        return false;
                    }
                }

                if (finalPart.Length < 2 || finalPart.Length > 4)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            // Everything ok
            return true;
        }

        private bool checkAt(string eMailAddress)
        {
            // Check if only one @
            int counter = 0;
            for (int i = 0; i < eMailAddress.Length; i++)
            {
                if (eMailAddress[i].Equals('@'))
                {
                    counter++;
                }
            }
            if (counter == 1)
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

