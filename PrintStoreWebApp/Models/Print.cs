using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Print
    {
        [Key]
        public int PrintID { get; set; }
        public string PrintTitle { get; set; }
        public string ArtistFName { get; set; }
        public string ArtistLName { get; set; }
        public double PrintPrice { get; set; }
        public string PrintImage { get; set; }
        public string PrintDecription { get; set; }

        //Ef relationship with inventory
        public ICollection<Inventory> Inventories {get; set;}

        //Ef relationship with orderline
        public ICollection<Orderline> Orderlines {get;set;}
    }
}