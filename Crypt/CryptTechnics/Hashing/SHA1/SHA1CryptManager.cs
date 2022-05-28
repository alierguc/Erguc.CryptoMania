using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Crypt.CryptTechnics.Hashing.SHA1
{
    internal class SHA1CryptManager
    {

        /// <summary>
        /// SHA1 Hash is Generates a 160-bit hash value. It is unidirectional. Decrypting it won't work.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>SHA1 Hash Value (String)</returns>
        static string SHA1Hash(string data)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(data));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
