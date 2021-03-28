using System;
using Models;
using Repository;

namespace BusinessLogic
{
    public class UserMethods
    {
        private readonly PrintStoreRepoLayer _repolayer;
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
    }
}