using System;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CustomerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UserMethods _business;
        public CustomerController(UserMethods business)
        {
            _business = business;
        }

        /// <summary>
        /// Controller route that takes in register request from sign up page
        /// </summary>
        /// <param name="rawcustomer"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public ActionResult<Customer> Register(RawCustomer rawcustomer)
        {
            Console.WriteLine("Customer name " + rawcustomer.CustomerFName);
            Customer customer = new Customer();
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else
            {
                Console.WriteLine("Raw customer fname " + rawcustomer.CustomerFName);
                Console.WriteLine("Raw customer lname" + rawcustomer.CustomerLName);
                Console.WriteLine("Raw customer email" + rawcustomer.CustomerEmail);
                Console.WriteLine("Raw customer pw" + rawcustomer.CustomerPassword);
                customer = _business.Register(rawcustomer);
            }

            //check if person is null!!!
            if (customer == null)
            {
                return StatusCode(409, "We're sorry, your new user was not successfully saved or a user of that username already exists.");
            }


            return customer;
        }

        /// <summary>
        /// Controller route which will take a user's sign information and
        /// check if username and password are a match in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("login/{username}/{password}")]
        public ActionResult<Customer> Login(string username, string password)
        {
            Customer customer = new Customer();
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else
            {
                customer = _business.Login(username, password);
            }

            //check if person is null!!!
            if (customer == null)
            {
                return StatusCode(409, "We're sorry, your username was not found.");
            }
            return customer;
        }


    }//end of class
}//end of namespace