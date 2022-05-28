using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Crypt.CryptTechnics.Hashing.SHA512
{
    internal static class SHA512CryptManager
    {/// <summary>
     /// SHA512 Hash is Generates a 512-bit hash value. It is unidirectional. Decrypting it won't work.
     /// </summary>
     /// <param name="data"></param>
     /// <returns>SHA512 Hash Value ( String )</returns>
        static string SHA512Hash(string data)
        {
            using (SHA512Managed sha512 = new SHA512Managed())
            {
                var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(data));
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
