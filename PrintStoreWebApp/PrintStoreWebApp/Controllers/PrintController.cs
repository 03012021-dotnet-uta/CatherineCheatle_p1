using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PrintStoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : ControllerBase
    {
        private readonly UserMethods _business;
        public PrintController(UserMethods business)
        {
            _business = business;
        }

        /// <summary>
        /// Controller Route that will return full print details for cart
        /// </summary>
        /// <param name="storename"></param>
        /// <param name="printname"></param>
        /// <returns></returns>
        [HttpGet("{storename}/{printname}")]
        public ActionResult GetPrintInfo(string storename, string printname)
        {
            IEnumerable<object> printDetail = new List<object>();

            //check if store name is empty, if it is return error code
            if(string.IsNullOrEmpty(storename))
            {
                StatusCode(422, "store name is empty");
            }
            else{
                //query database
                //Make call to business layer to get a store inventory
                Console.WriteLine("Made it to controller. calling business method");
                printDetail = _business.GetPrintInfo(storename, printname);
            }

            //check if the query result is empty
            if(printDetail == null)
            {
                return StatusCode(422, "Query came back empty. Unable to retrieve inventory");
            }

            return Ok(printDetail);
            
        }
    }
}