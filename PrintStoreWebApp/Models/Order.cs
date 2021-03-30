using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Order
    {
        [Key]
        public int OrdersId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public double OrderSubtotal { get; set; }
        public double OrderTax { get; set; }
        public double OrderTotalPrice { get; set; }


        //Ef relation with customer
        public int CustomerId { get; set; }
        public Customer customer {get; set;}

        //Ef relation with store
        public int StoreId { get; set; }
        public Store Store {get; set;}

        //Ef relationship with orderline
        public ICollection<Orderline> Orderlines {get;set;}
    }
}