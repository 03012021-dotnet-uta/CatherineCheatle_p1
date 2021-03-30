using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Inventory
    {
        //Ef Relations with store and print
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int PrintId { get; set; }
        public Print Print { get; set; }
        
        public int PrintQty { get; set; }
    }
}