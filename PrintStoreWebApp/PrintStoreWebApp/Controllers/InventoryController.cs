using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

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

        /// <summary>
        /// Controller Route that will take input and pass request to query the database to 
        /// get the number of prints left in the store's inventory
        /// </summary>
        /// <param name="storename"></param>
        /// <param name="printname"></param>
        /// <returns>int (number of available prints)</returns>
        [HttpGet("storePrintAvailability/{storename}/{printname}")]
        public ActionResult<int> GetPrintAvailability(string storename, string printname)
        {
            var numOfPrintsAvailable = 0;

            // if storename or printname is empty, return error
            if(String.IsNullOrEmpty(storename) || String.IsNullOrEmpty(printname))
            {
                return StatusCode(422, "store name or print name is empty");
            }
            else{
                //Make a call to business layer to query db
                numOfPrintsAvailable = _business.GetPrintQuantity(storename, printname);
                return numOfPrintsAvailable;
            }
        }

        /// <summary>
        /// Controller Route to take in a store name and print name to decrease inventory for that
        /// store and print
        /// </summary>
        /// <param name="storename"></param>
        /// <param name="printname"></param>
        /// <returns></returns>
        [HttpPost("decreaseInventory")]
        public ActionResult<bool> DecreaseInventory([FromBody] EditInventory editInventory)
        {
            bool wasSuccessful = false;

            //if storename or printname is empty
            if (!ModelState.IsValid)// did the conversion from JS to C# work?
            {
                return StatusCode(400, "That was a failue of modelbinding");
            }
            else{
                // make call to business layer
                wasSuccessful= _business.DecreaseInventory(editInventory);
            }

            return wasSuccessful;
            
        }

        
    }
}