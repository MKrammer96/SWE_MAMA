using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography; // for DES
using System.IO; // for FileStream

namespace MAMA
{
    class Encryption
    {
        //static void Main(string[] args)
        //{
        //    String cPassPhrase;
        //    String cTextIn;

        //    // get input 
        //    Console.WriteLine("Input text to encrypt");
        //    cTextIn = Console.ReadLine();
        //    do
        //    {
        //        Console.WriteLine("Input a pass phrase (like a key) - with 8 characters");
        //        cPassPhrase = Console.ReadLine();
        //    } while (cPassPhrase.Length != 8); // based on DES block size

        //    // do it
        //    encrypt(cTextIn, cPassPhrase);

        //    // check it
        //    String cTest = decrypt(cPassPhrase);
        //    if (cTest == cTextIn)
        //    {
        //        Console.WriteLine("Perfectly reconstructed");
        //    }
        //    else
        //    {
        //        Console.WriteLine("There seems to be a problem...");
        //    }
        //    Console.WriteLine("Test: {0}", cTest);
        //}

        public static void encrypt(String cTextIn, String cPassPhrase)
        {
            // write output to a file
            byte[] buffer = new byte[100];
            FileStream fencrypted = new FileStream(@"c:\temp\encryp.txt", FileMode.OpenOrCreate, FileAccess.Write);
            fencrypted.SetLength(0); // empty any old contents

            DES des = new DESCryptoServiceProvider();
            des.Key = Encoding.ASCII.GetBytes(cPassPhrase);
            des.IV = Encoding.ASCII.GetBytes(cPassPhrase); // use same
            CryptoStream encStream = new CryptoStream(fencrypted, des.CreateEncryptor(), CryptoStreamMode.Write);

            // encrypt text from parameter and write to the file
            // - CryptoStream linked to File, so write to CryptoStream
            // - CryptoStream basically bytes (remember so are chars)
            Console.WriteLine("Encrypting...");
            buffer = Encoding.ASCII.GetBytes(cTextIn);
            encStream.Write(buffer, 0, cTextIn.Length);

            encStream.Close();
            fencrypted.Close();
        }

        public static String decrypt(String cPassPhrase)
        {
            String cTextOut;
            const int bufsize = 100;
            byte[] buffer = new byte[bufsize];

            // text to decrypt
            FileStream fencrypted = new FileStream(@"c:\temp\encryp.txt", FileMode.Open, FileAccess.Read);

            DES des = new DESCryptoServiceProvider();
            des.Key = Encoding.ASCII.GetBytes(cPassPhrase);
            des.IV = Encoding.ASCII.GetBytes(cPassPhrase); // use same
            CryptoStream encStream = new CryptoStream(fencrypted, des.CreateDecryptor(), CryptoStreamMode.Read);

            //decrypt and store in string
            Console.WriteLine("Decrypting...");
            encStream.Read(buffer, 0, bufsize);
            cTextOut = Encoding.ASCII.GetString(buffer, 0, (int)fencrypted.Length);

            // since always encodes in blocks, may have extra chars at the end
            int end = cTextOut.IndexOf('\0');
            cTextOut = cTextOut.Substring(0, end);

            encStream.Close();
            fencrypted.Close();

            return cTextOut;
        }
    }

}
