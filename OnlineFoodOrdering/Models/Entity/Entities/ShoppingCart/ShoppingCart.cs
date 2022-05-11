using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class ShoppingCart
    {
        [Key]
        public int id { get; set; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }
        public Customer customer { get; set; }
        public List<CartItem> cartItems { get; set; }
    }
}