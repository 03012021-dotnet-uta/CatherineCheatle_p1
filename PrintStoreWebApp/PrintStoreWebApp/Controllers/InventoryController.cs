using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace PrintStoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly UserMethods _business;
        public InventoryController(UserMethods business)
        {
            _business = business;
        }

        /// <summary>
        /// This will take in a store name then pass that infomation to a method
        /// in the business layer for later query. Should return a list of objects
        /// with information about store, print and qty
        /// </summary>
        /// <param name="storeName"></param>
        /// <returns>Object</returns>
        [HttpGet("storeInventory/{storename}")]
        public ActionResult GetStoreInventory(string storename)
        {
            IEnumerable<object> storeInventory = new List<object>();

            //check if store name is empty, if it is return error code
            if(string.IsNullOrEmpty(storename))
            {
                StatusCode(422, "store name is empty");
            }
            else{
                //query database
                //Make call to business layer to get a store inventory
                Console.WriteLine("Made it to controller. calling business method");
                storeInventory = _business.GetInventory(storename);
            }

            //check if the query result is empty
            if(storeInventory == null)
            {
                return StatusCode(422, "Query came back empty. Unable to retrieve inventory");
            }

            return Ok(storeInventory);
            
        }

        
    }
}