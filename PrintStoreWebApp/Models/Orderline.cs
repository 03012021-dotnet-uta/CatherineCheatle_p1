using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Orderline
    {
        [Key]
        public int OrderNumId { get; set; }
        public int PrintId { get; set; }
        public int PrintQty { get; set; }
    }
}