using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PrintStoreWebApp.Controllers
{
    public class StoreController: ControllerBase
    {
        private readonly UserMethods _business;

        public StoreController(UserMethods business)
        {
            _business = business;
        }

    /// <summary>
    /// Controller Route that will return all the stores with this database
    /// </summary>
    /// <returns></returns>
        // [HttpGet]
        // public ActionResult<Store> GetAllStores()
        // {
            
        // }
    }
}