using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWMS.Service.Helpers
{
    public static class StringHelper
    {
        public static string GetSHA(string source)
        {
            SHA256Managed sha256 = new SHA256Managed();
            byte[] s = UTF8Encoding.UTF8.GetBytes(source);
            byte[] t = sha256.ComputeHash(s);
            return Convert.ToBase64String(t);
        }
        public static string ToSHA(this string source)
        {
            return GetSHA(source);
        }
    }
}
