using System;
using System.Collections.Generic;
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

        public Customer Login(string username, string password)
        {
            //Check if user exists
            if (!_repolayer.UserExist(username))
            {
                return null;
            }
            else
            {
                //get matching user with username
                Customer existingCustomer = _repolayer.GetCustomerByUsername(username);

                // hash password with key from user
                byte[] hash = mapper.HashTheUsername(password, existingCustomer.CustomerPasswordSalt);

                // compare hashes, if they match return the user
                if (CompareTwoHashes(existingCustomer.CustomerPasswordHash, hash))
                {
                    return existingCustomer;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool CompareTwoHashes(byte[] arr1, byte[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            //compare the hash of the inputted password and the found user
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                } // Unauthorized("Invalid Password");
            }
            return true;
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

        /// <summary>
        /// This method will call a method in the repo layer, to query
        /// the database and will loop through the stores and return 
        /// only the names of the stores
        /// </summary>
        /// <returns></returns>
        public List<string> GetStores()
        {
            var storeNames = new List<string>();
            var storeList = _repolayer.GetStores();
            foreach (Store s in storeList)
            {
                storeNames.Add(s.StoreName);
            }

            return storeNames;
        }

        /// <summary>
        /// This method takes in a store name and will pass it to the
        /// repo layer to be queried to the database. It should return a list 
        /// of objects that give information about store, print and qty
        /// </summary>
        /// <param name="storeName"></param>
        /// <returns>List<Object></returns>
        public IEnumerable<object> GetInventory(string storeName)
        {
            Console.WriteLine("Made it to business layer, calling repo method");
            //call method in repo layer to query database
            var storeInventory = _repolayer.GetStoreInventory(storeName);

            return storeInventory;
        }

        /// <summary>
        /// In the business layer, the input will be passed to repolayer
        /// to query the database to return number of prints available in the store
        /// </summary>
        /// <param name="storename"></param>
        /// <param name="printname"></param>
        /// <returns>int (number of available prints)</returns>
        public int GetPrintQuantity(string storename, string printname)
        {
            //call repolayer to query the database
            var printQuantity = _repolayer.GetPrintQuantity(storename, printname);
            return printQuantity;
        }

        /// <summary>
        /// Sends input to repo layer store and print name to query the database for
        /// details about the print, store id, and inventory qty  
        /// /// </summary>
        /// <param name="storename"></param>
        /// <param name="printname"></param>
        /// <returns>Print detail object</returns>
        public IEnumerable<object> GetPrintInfo(string storename, string printname)
        {
            var printDetail = _repolayer.GetPrintInfo(storename, printname);

            return printDetail;
        }

        /// <summary>
        /// Method that get inventory from store and print id to update the
        /// database to decrease the inventory
        /// </summary>
        /// <param name="storename"></param>
        /// <param name="printname"></param>
        public bool DecreaseInventory(EditInventory editInventory)
        {
            Inventory dbInventory = _repolayer.GetInventoryByStoreAndPrintID(editInventory.StoreID, editInventory.PrintID);

            if(dbInventory == null)
            {
                return false;
            }

            dbInventory.PrintQty = dbInventory.PrintQty - editInventory.PurchaseQty;
            _repolayer.SaveChanges();
            return true;
        }


    }
}