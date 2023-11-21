using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WMS.utiles
{
    public static class Tools
    {
        public static string hashedPassword (string password,string salt)
        {
            var passwordsalt = salt;
            var saltedPassword = password + passwordsalt;
            var saltedPasswordBytes = System.Text.Encoding.UTF8.GetBytes(saltedPassword);
            return Convert.ToBase64String(SHA512.Create().ComputeHash(saltedPasswordBytes));
        }

    }
}