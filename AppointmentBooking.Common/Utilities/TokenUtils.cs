using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Common.Utilities
{
    public class TokenUtil
    {
        public static string GenerateToken(string stringReferrence)
        {
            return GenerateHash(stringReferrence);
        }

        public static string GenerateHash(string text)
        {
            using (var hash = SHA256.Create())
            {
                return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(text)));
            }
        }

        public static bool CompareHash(string hash, string text)
        {
            return GenerateHash(text) == hash;
        }
    }
}
