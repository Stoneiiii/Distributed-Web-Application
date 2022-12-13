using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class encrypt
    {
        public static string Encrypt(string password)
        {
            if (password == null)
            {
                return "password is empty!";
            }
            MD5 md5 = MD5.Create(); //Creat a md5 instance;

            byte[] pw = md5.ComputeHash(Encoding.Default.GetBytes(password));   //convert string to bytes type and encrytion
            return Convert.ToBase64String(pw); //convert byte to base64 and return;
        }
    }
}
