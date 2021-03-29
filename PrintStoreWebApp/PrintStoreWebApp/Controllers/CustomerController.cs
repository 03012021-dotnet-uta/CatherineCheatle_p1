using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PrintStoreWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController
    {
        private readonly UserMethods business;
        public CustomerController(UserMethods business)
        {
            this.business = business;
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
        [HttpPost]
        // [Route("/postrequest")]
        public Customer Post([FromBody] Customer obj)
        {
            Console.WriteLine($"YAY! we made it to the C# side with {obj.CustomerEmail}, {obj.CustomerPasswordSalt}. ");
            //call a method in the business logic layer.
            //the business logic layer implements business requirements. Thisi s where the majority of 
            // the data manipulation will be.
            Customer obj1 = business.Login(obj);

            return obj1;
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