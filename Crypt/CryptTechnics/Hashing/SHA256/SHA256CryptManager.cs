using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Crypt.CryptTechnics.Hashing.SHA256
{
    internal static class SHA256CryptManager
    {
        /// <summary>
        /// SHA256 Hash is Generates a 256-bit hash value. It is unidirectional. Decrypting it won't work.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>SHA256 Hash Value ( String )</returns>
        static string SHA256Hash(string data)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
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
