using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Order
    {
        [Key]
        public int OrdersId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public double OrderSubtotal { get; set; }
        public double OrderTax { get; set; }
        public double OrderTotalPrice { get; set; }
    }
}