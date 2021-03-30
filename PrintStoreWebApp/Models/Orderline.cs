using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Orderline
    {
        //Ef Relationship for Order
        public int OrderNumId { get; set; }
        public Order Order { get; set; }

        //Ef Relationship for Print
        public int PrintId { get; set; }
        public Print Print { get; set; }
        
        public int PrintQty { get; set; }
    }
}