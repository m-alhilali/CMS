using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Global
{
    public class clsHashPassword
    {
        public static string ComputeHash(string Password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes=sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
