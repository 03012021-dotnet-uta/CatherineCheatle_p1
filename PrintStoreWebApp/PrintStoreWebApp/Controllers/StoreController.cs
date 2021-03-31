using System.Collections.Generic;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PrintStoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly UserMethods _business;

        public StoreController(UserMethods business)
        {
            _business = business;
        }

        /// <summary>
        /// Controller Route that will return all the stores within the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("getStores")]
        public ActionResult GetAllStores()
        {
            // call to business layer to get stores
            var storeNames = _business.GetStores();

            //if null there was an error
            if (storeNames == null)
            {
                return StatusCode(409, "Sorry store names not found");
            }

            return Ok(storeNames);

        }
    }
}