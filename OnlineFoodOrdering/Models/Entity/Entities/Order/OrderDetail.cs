using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class OrderDetail
    {

        [Key]
        public int OrderItemsId { get; set; }

        public int Quantity { get; set; }

        
        public double TotalPrice{ get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int FoodItemId { get; set; }
        public virtual FoodItem FoodItem { get; set; }
    }
}