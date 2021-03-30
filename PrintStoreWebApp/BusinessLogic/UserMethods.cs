using System;
using Models;
using Repository;

namespace BusinessLogic
{
    public class UserMethods
    {
        private readonly PrintStoreRepoLayer _repolayer;
        private readonly mapper _mapper = new mapper();
        public UserMethods() { }
        public UserMethods(PrintStoreRepoLayer repolayer)
        {
            _repolayer = repolayer;
        }

        /// <summary>
        /// This method with take a user and verify if it exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public Customer Login(Customer user)
        {
            //call method in repo to query db
            //if user exists then log in if creditials are good
            //otherwise return empty user
            Customer userReturned = _repolayer.Login(user);

            //if user exists and password check passes
            // if()
            // {
            //     Console.write("Welcome");
            // }

            //if user doesn't exist or if password doesnt match


            return userReturned;
        }

        /// <summary>
        /// This method will call a method in the repolayer to query the database
        /// to see if the user exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Customer Register(RawCustomer rawUser)
        {
            //Check if user exists
            if (_repolayer.UserExist(rawUser.CustomerEmail) == true)
            {
                Console.WriteLine("Customer already exist");
                return null;
            }
            else
            {
                Console.WriteLine("Create new customer");
                var pw = rawUser.CustomerPassword;
                Console.WriteLine("password type: " + pw);
                //Convert raw person to customer
                Customer newCustomer = mapper.GetANewCustomerWithHashedPassword(rawUser.CustomerPassword);

                newCustomer.CustomerFName = rawUser.CustomerFName;
                newCustomer.CustomerLName = rawUser.CustomerLName;
                newCustomer.CustomerEmail = rawUser.CustomerEmail;

                //Call the repo layer to add person to db
                Customer registeredCustomer = _repolayer.Register(newCustomer);
                return registeredCustomer;
            }
        }


    }
}