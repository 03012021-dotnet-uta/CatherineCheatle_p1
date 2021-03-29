using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Abstracts
{
    public class AStore
    {
        [Key]
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreStreet { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public int StoreZip { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}