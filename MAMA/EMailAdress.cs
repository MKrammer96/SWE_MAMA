using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAMA
{
    public class EMailAdress
    {
        string _adress;

        public EMailAdress(string adress)
        {
            if (verifyEmailAdress(adress))
            {
                _adress = adress;
            }
            else
            {
                _adress = "";
            }
        }

        /// <summary>
        /// Updates your EMail-Adress
        /// </summary>
        /// <param name="adress">e-Mail Adress</param>
        public void updateEmailAdress(string adress)
        {
            if (verifyEmailAdress(adress))
            {
                _adress = adress;
            }
            else
            {
                _adress = "";
            }
        }

        /// <summary>
        /// Returns your EMail-Adress
        /// </summary>
        /// <returns></returns>
        public string getEmailAdress()
        {
            return _adress;
        }

        /// <summary>
        /// Checks your EMail-Adress ("" if false)
        /// </summary>
        /// <param name="eMailAdress"></param>
        /// <returns></returns>
        public bool verifyEmailAdress(string eMailAdress)
        {
            bool cond0, cond1, cond2, cond3;
            cond0 = false;
            cond1 = false;
            cond2 = false;
            cond3 = false;

            // Ausbauen
            cond0 = checkIfString(eMailAdress);

            // Check @
            if (cond0)
            {
                cond1 = checkAt(eMailAdress);
            }

            if (cond1)
            {
                string[] splitAdress = eMailAdress.Split('@');
                cond2 = checkAfterAT(splitAdress[1]);
                cond3 = checkBeforeAT(splitAdress[0]);
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

        private bool checkIfString(string eMailAdress)
        {
            // Check last Condition
            if (eMailAdress == null)
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

        private bool checkAt(string eMailAdress)
        {
            // Check if only one @
            int counter = 0;
            for (int i = 0; i < eMailAdress.Length; i++)
            {
                if (eMailAdress[i].Equals('@'))
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

