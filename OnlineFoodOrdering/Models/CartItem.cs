using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class CartItem
    {
        public int shoppingCartId { get; set; }
        public ShoppingCart shoppingCart { get; set; }
        public int foodItemId { get; set; }
        public FoodItem foodItem { get; set; }

        public int quantity { get; set; }
        public double totalPrice { get; set; }

    }
}