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
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public Customer Login(Customer user)
        {
            //use the context to call on the database to query for user
            //Customer user1 = PrintStoreContext.Customer;  
            Customer user1 = new Customer
            {
                CustomerId = 0,
                CustomerEmail = "lilyjames@gmail.com",
            };
            return user1;
        }
    }
}