using System;
using System.Collections;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PrintStoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserMethods _business;
        public OrderController(UserMethods business)
        {
            _business = business;
        }

        /// <summary>
        /// Controller route for  placing an order
        /// </summary>
        /// <param name="raworder"></param>
        /// <returns></returns>
        [HttpPost("placeorder")]
        public ActionResult<Order> PlaceOrder(RawOrder raworder)
        {
            Console.WriteLine(raworder);
            Order order = new Order();

            if(!ModelState.IsValid)
            {
                Console.WriteLine("Problem with model binding");
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else{
                //call business layer
                Console.WriteLine("Made it to controller, now passing to business");
                order = _business.PlaceOrder(raworder);
            }

            return order;
        }

        /// <summary>
        /// Controller route to update an order to include its order line
        /// </summary>
        /// <param name="orderlines"></param>
        /// <returns></returns>
        [HttpPost("addorderline")]
        public ActionResult<bool> AddOrderline([FromBody] RawOrdelines raworderlines){
            bool wasSuccessful = false;

            //if storename or printname is empty
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else{
                // make call to business layer
                wasSuccessful= _business.AddOrderline(raworderlines);
            }

            return wasSuccessful;

        }
    }//end of class
}