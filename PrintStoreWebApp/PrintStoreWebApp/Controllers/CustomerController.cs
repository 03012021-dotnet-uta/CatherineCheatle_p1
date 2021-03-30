using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;

namespace PrintStoreWebApp.Controllers
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

        //GET: api/CustomerController
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Firstname", "LastName" };
        }

        //GET: api/CustomerController/{id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost("login")]
        // [Route("/postrequest")]
        public Customer Post([FromBody] Customer obj)
        {
            Console.WriteLine($"YAY! we made it to the C# side with {obj.CustomerEmail}, {obj.CustomerPasswordSalt}. ");
            //call a method in the business logic layer.
            //the business logic layer implements business requirements. Thisi s where the majority of 
            // the data manipulation will be.
            Customer obj1 = _business.Login(obj);

            return obj1;
        }

        [HttpPost("register")]
        public ActionResult<Customer> Register(RawCustomer rawcustomer)
        {
            Customer customer = new Customer();
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else
            {
                Console.WriteLine($"{rawcustomer.CustomerFName}, {rawcustomer.CustomerLName}");
                System.Console.WriteLine("Made it to Controller with raw customer " + rawcustomer.CustomerFName);
                customer = _business.Register(rawcustomer);
            }

            if (customer == null)
            {
                return StatusCode(409, "We're sorry, your new user was not successfully saved or a user of that username already exists.");
            }


            return customer;
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}