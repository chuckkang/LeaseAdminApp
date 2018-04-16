using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
namespace DBConnectionTest.BusinessLogic
{
    public class Authenticate
    {
        public static string SHA1(string input)
        {
            byte[] hash;

            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
            }
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {// ':' = lowercase, "x" = lowercase x means lowercase and hexidecimal "2" means it is two characters
                sb.AppendFormat("{0:x2}", b);
            }

            return sb.ToString();
        }

        public static bool CompareHash(string submittedpass, string storedpass)
        {
            return submittedpass == storedpass;
        }
    }
}