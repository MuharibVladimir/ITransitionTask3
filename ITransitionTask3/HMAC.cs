using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ITransitionTask3
{
    public static class HMAC
    {
        public static byte[] GenerateKey()
        {
            var secretKey = new byte[256];

            var random = RandomNumberGenerator.Create();
            random.GetNonZeroBytes(secretKey);

            return secretKey;
        }

        public static string GenerateHMAC(byte[] secretKey, string pcMove)
        {
            using (HMACSHA256 hmac = new HMACSHA256(secretKey))
            {
                byte[] hashValue = hmac.ComputeHash(Encoding.Default.GetBytes(pcMove));
                var result = BitConverter.ToString(hashValue).Replace("-", "");

                return result;
            }
        }
    }
}
