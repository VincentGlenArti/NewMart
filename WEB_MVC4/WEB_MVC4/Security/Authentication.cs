using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using WEB_MVC4.Models;
using System.Web.Security;
using System.Web.Mvc;
using System.Web;
using System.Security.Principal;

namespace WEB_MVC4.Security
{
    public class Authentication
    {

        private databaseModelContainer DataBase = new databaseModelContainer();

        public bool ValidateUser(string username, string password)
        {
            String PassHash = HashPassword(password);
            User User = DataBase.UserSet
                .Where(user => user.Login == username && user.Password == PassHash)
                .Select(user => user)
                .FirstOrDefault();
            return User != null;
        }

        public User GetUserInfo(string username)
        {
            User User = DataBase.UserSet
                .Where(user => user.Login == username)
                .Select(user => user)
                .FirstOrDefault();

            return User;
        }

        public bool EMailExists(string Email)
        {
            return (DataBase.UserSet.Where(user => user.Email == Email).Select(user => user).FirstOrDefault() != null);
        }

        public bool UserExists(string Login)
        {
            return (DataBase.UserSet.Where(user => user.Login == Login).Select(user => user).FirstOrDefault() != null);
        }

        public string HashPassword(string password)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            HashAlgorithm hash = HashAlgorithm.Create("MD5");

            if (password != null && hash != null && encoding != null)
            {
                byte[] valueToHash = new byte[encoding.GetByteCount(password)];
                byte[] binaryPassword = encoding.GetBytes(password);
                binaryPassword.CopyTo(valueToHash, 0);
                byte[] hashValue = hash.ComputeHash(valueToHash);
                string hashedPassword = "";
                foreach (byte hexdigit in hashValue)
                {
                    hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }

                return hashedPassword;
            }

            return null;
        }

        public bool Register(RegistrationPageView RegUser)
        {
            bool Target = true;
            try
            {
                User Reg = new User() { Name = RegUser.Name, LastName = RegUser.LastName, Email = RegUser.Email, 
                    Login = RegUser.Login, Password = HashPassword(RegUser.Password)};
                if (RegUser.PhoneNumber != null)
                    if (!RegUser.PhoneNumber.Equals(""))
                        Reg.Phone = RegUser.PhoneNumber;
                DataBase.UserSet.Add(Reg);
                DataBase.SaveChanges();
            }
            catch(Exception e)
            {
                Target = false;
            }
            return Target;
        }
    }
}