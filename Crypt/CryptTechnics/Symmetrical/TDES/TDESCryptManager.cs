using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crypt.CryptTechnics.Symmetrical.TDES
{
    internal static class TDESCryptManager
    {
        static byte[] TDESEncrypt(string data, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
               
                ICryptoTransform encryptor = tdes.CreateEncryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream())
                {
               
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(data);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data  
            return encrypted;
        }
        static string TDESDecrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create TripleDESCryptoServiceProvider  
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
              
                ICryptoTransform decryptor = tdes.CreateDecryptor(Key, IV);
                using (MemoryStream ms = new MemoryStream(cipherData))
                {
                    // Create crypto stream  
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream  
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
        private static void TDESEncryptFile(String inputName, String outputName, byte[] desKey, byte[] desIV)
        {
            FileStream fin = new FileStream(inputName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outputName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            byte[] bin = new byte[100]; 
            long rdlen = 0;
            long totlen = fin.Length;
            int len;
            using System.Security.Cryptography.DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
            Console.WriteLine("Encrypting...");
           
            while (rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
                Console.WriteLine("{0} bytes processed", rdlen);
            }
            encStream.Close();
            fout.Close();
            fin.Close();
        }
    }
}
