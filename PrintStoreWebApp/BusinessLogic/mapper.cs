using System.Security.Cryptography;
using System.Text;
using Models;

namespace BusinessLogic
{
    public class mapper
    {

        /// <summary>
        /// This method will take a user's passward and return a
        /// hashed password
        /// </summary>
        /// <param name="passwordString"></param>
        /// <returns></returns>
        public static Customer GetANewCustomerWithHashedPassword(string passwordString)
        {
            using(var hmac = new HMACSHA512())
            {
                Customer user = new Customer()
                {
                    CustomerPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordString)),
                    CustomerPasswordSalt = hmac.Key
                };

                return user;
            }
        }

        /// <summary>
        /// This method with take user's entered password and hash the password
        /// to later be checked against password stored in the database
        /// </summary>
        /// <param name="password"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] HashTheUsername(string password, byte[] key)
        {
            using HMACSHA512 hmac = new HMACSHA512(key: key);

            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hashedPassword;
        }
    }
}