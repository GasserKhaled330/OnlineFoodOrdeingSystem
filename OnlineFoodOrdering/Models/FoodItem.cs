using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class FoodItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string foodItemImage { get; set; }

        public List<CartItem> cartItems { get; set; }


    }

}