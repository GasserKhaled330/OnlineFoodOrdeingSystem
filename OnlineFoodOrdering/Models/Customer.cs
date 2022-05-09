using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class Customer 
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Address address { get; set; }

    }
}