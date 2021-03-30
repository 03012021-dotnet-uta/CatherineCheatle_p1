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
    }
}