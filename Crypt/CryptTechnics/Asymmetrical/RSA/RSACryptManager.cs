using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crypt.CryptTechnics.Asymmetrical.RSA
{
    internal static class RSACryptManager
    {
        public static string RSAEncrypt(string Enryptdata, System.Security.Cryptography.RSA rsa)
        {
            byte[] data = Encoding.UTF8.GetBytes(Enryptdata);
            byte[] cipherText = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(cipherText);
        }

        public static string RSADecrypt(string Decrypttext, System.Security.Cryptography.RSA rsa)
        {
            byte[] data = Convert.FromBase64String(Decrypttext);
            byte[] cipherText = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(cipherText);
        }
    }
}
