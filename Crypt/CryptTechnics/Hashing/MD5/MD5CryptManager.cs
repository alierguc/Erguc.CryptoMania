using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Crypt.CryptTechnics.Hashing.MD5
{
    internal class MD5CryptManager
    {

        /// <summary>
        /// MD5 is Generates a 128-bit hash value. It is unidirectional. Decrypting it won't work.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>MD5 Hash Value (String)</returns>
        public static string MD5Hash(string data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider(); 
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            byteData = md5.ComputeHash(byteData);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in byteData)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
