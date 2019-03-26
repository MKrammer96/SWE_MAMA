using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography; // for DES

namespace MAMA
{
    public class Encryption
    {
        private string _encryptedText;
        AesCryptoServiceProvider aesCSP;

        /// <summary>
        /// Creates a new Crypto Provider
        /// </summary>
        /// <param name="userinput">Select your Password</param>
        public Encryption(string userinput)
        {
            aesCSP = new AesCryptoServiceProvider();

            aesCSP.GenerateKey();
            aesCSP.GenerateIV();

            _encryptedText = encrpyt(userinput);
        }


        private byte[] EncryptString(SymmetricAlgorithm symAlg, string inString)
        {
            byte[] inBlock = UnicodeEncoding.Unicode.GetBytes(inString);
            ICryptoTransform xfrm = symAlg.CreateEncryptor();
            byte[] outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);

            return outBlock;
        }

        /// <summary>
        /// Returns the encrypted Password
        /// </summary>
        /// <returns></returns>
        public string getEncryptedText()
        {
            return _encryptedText;
        }

        /// <summary>
        /// Encrypts your Input
        /// </summary>
        /// <param name="userinput">Userinput</param>
        /// <returns></returns>
        public string encrpyt(string userinput)
        {
            byte[] encQuote = EncryptString(aesCSP, userinput);

            return Convert.ToBase64String(encQuote);
        }
        
    }

}
