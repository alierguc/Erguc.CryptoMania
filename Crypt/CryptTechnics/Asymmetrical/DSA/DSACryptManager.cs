using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crypt.CryptTechnics.Asymmetrical.DSA
{
    internal static class DSACryptManager
    {
        public static string DSASign(string Data, System.Security.Cryptography.RSA rsa)
        {
            byte[] data = Encoding.UTF8.GetBytes(Data);
            byte[] signature = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return Convert.ToBase64String(signature);
        }

        public static bool DSAVerify(string text, string signatureBase64, System.Security.Cryptography.RSA rsa)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] signature = Convert.FromBase64String(signatureBase64);
            bool isValid = rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return isValid;
        }
    }
}
