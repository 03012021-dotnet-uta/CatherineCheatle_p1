using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreStreet { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public int StoreZip { get; set; }

        //Ef relationship with store
        public ICollection<Order> Orders { get; set; }

        //Ef relationship with inventory
        public ICollection<Inventory> Inventories {get; set;}
    }
}