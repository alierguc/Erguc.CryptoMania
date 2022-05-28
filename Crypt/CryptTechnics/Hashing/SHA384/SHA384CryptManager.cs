using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Crypt.CryptTechnics.Hashing.SHA384
{
    internal static class SHA384CryptManager
    {
        /// <summary>
        /// SHA384 Hash is Generates a 160-bit hash value. It is unidirectional. Decrypting it won't work.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>SHA384 Hash Value ( String )</returns>
        static string SHA384Hash(string data)
        {
            using (SHA384Managed sha384 = new SHA384Managed())
            {
                var hash = sha384.ComputeHash(Encoding.UTF8.GetBytes(data));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
