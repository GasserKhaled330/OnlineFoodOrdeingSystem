using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineFoodOrdering.Models;

namespace OnlineFoodOrdering.ViewModels
{
    public class ShopingCartAndCartItemsViewModel
    {
        public ShoppingCart shoppingCart { get; set; }
        public List<CartItem> cartItems { get; set; }
    }
}