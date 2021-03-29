using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public byte[] CustomerPasswordHash { get; set; }
        public byte[] CustomerPasswordSalt { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public int CustomerZip { get; set; }
        public string CustomerPhone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}