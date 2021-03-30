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

        public Customer GetCustomerByUsername(string username)
        {
            Customer existingCustomer = _context.Customers.FirstOrDefault(c => c.CustomerEmail == username);
            return existingCustomer;
        }
        
    }//end of class
}//end of namespace