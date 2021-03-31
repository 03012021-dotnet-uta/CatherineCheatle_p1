using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Repository
{
    public class PrintStoreRepoLayer
    {
        private readonly PrintStoreContext _context;
        public PrintStoreRepoLayer(PrintStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This will make a db query to see if user exists
        /// If user exists then customer is return
        /// If not user is returned as null
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Customer Login(Customer user)
        {
            //use the context to call on the database to query for user 
            var requestedUser = _context.Customers
                                .Where(u => u.CustomerEmail == user.CustomerEmail)
                                .FirstOrDefault<Customer>();

            return requestedUser;
        }

        /// <summary>
        /// Method to check if a user exists in the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        public bool UserExist(string username)
        {
            System.Console.WriteLine("Made it to repo layer user exist");
            if (_context.Customers.FirstOrDefault(u => u.CustomerEmail == username) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method will add a new customer to the database, and return 
        /// customer object from the database
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns>Customer</returns>
        public Customer Register(Customer newCustomer)
        {
            System.Console.WriteLine("Customer creation repolayer");
            var newCustomer1 = _context.Customers.Add(newCustomer);// addd the new person to the Db
            _context.SaveChanges();// save the change.
            return _context.Customers.FirstOrDefault(p => p.CustomerId == newCustomer.CustomerId);// default is null
        }

        /// <summary>
        /// This method will query the database with username to 
        /// retrieve customer 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Customer GetCustomerByUsername(string username)
        {
            Customer existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerEmail == username);
            return existingCustomer;
        }

        /// <summary>
        /// This method will query the database for list of stores
        /// </summary>
        /// <returns>Stores</returns>
        public IEnumerable<Store> GetStores()
        {
            var stores = _context.Stores.ToList();
            return stores;
        }

        /// <summary>
        /// This method will query the database for a store's inventory
        /// It should return a list of objects that will tell information
        /// about the store, print and qty
        /// </summary>
        /// <param name="storeName"></param>
        /// <returns></returns>
        public IEnumerable<object> GetStoreInventory(string storeName)
        {
            Console.WriteLine("Made it to repo, querying data base");
            // Query for a left join beween inventory and print tables
            var query = (from i in _context.Inventories
                         join p in _context.Prints on i.PrintId equals p.PrintID into invent
                         from storeInventory in invent.DefaultIfEmpty()
                         where i.Store.StoreName == storeName
                         select new
                         {
                             i.StoreId,
                             i.PrintId,
                             i.PrintQty,
                             PrintName = storeInventory.PrintTitle,
                             PrintPrice = storeInventory.PrintPrice,
                             PrintImage = storeInventory.PrintImage,
                             PrintDescrip = storeInventory.PrintDecription,
                             PrintArtistFName = storeInventory.ArtistFName,
                             PrintArtistLName = storeInventory.ArtistLName
                         }).ToList();

            Console.WriteLine(query);
            return query;
        }
    }//end of class
}//end of namespace