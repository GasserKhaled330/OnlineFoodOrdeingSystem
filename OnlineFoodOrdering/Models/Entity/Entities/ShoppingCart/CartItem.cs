using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice
        {
            get { return FoodItem.price * Quantity; }
        }

        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public int FoodItemId { get; set; }

        public virtual FoodItem FoodItem { get; set; }

    }
}