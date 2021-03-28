using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System;
namespace PrintStoreWebApp.Controllers
{
    [ApiController]
    [Route("api/printstore")]
    public class PrintStoreContoller : ControllerBase
    {
        private readonly UserMethods business;
        public PrintStoreContoller(UserMethods business)
        {
            this.business = business;
        }

        //GET: api/PrintStoreController
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Firstname", "LastName" };
        }

        //GET: api/PrintStoreController/{id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrintStoreController>
        [HttpPost]
        // [Route("/postrequest")]
        public Customer Post([FromBody] Customer obj)
        {
            Console.WriteLine($"YAY! we made it to the C# side with {obj.CustomerEmail}, {obj.CustomerPassword}. ");
            //call a method in the business logic layer.
            //the business logic layer implements business requirements. Thisi s where the majority of 
            // the data manipulation will be.
            Customer obj1 = business.Login(obj);

            return obj1;
        }

        // PUT api/<PrintStoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrintStoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}