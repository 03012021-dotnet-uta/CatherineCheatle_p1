using System;
using System.Collections.Generic;

namespace Models
{
    public class RawOrder
    {
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public string OrderDate { get; set; }
        public string OrderDeliveryDate { get; set; }
        public double OrderSubtotal { get; set; }
        public string OrderTax { get; set; }
        public string OrderTotalPrice { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerZip { get; set; }
        public string CustomerPhone { get; set; }
    }
}