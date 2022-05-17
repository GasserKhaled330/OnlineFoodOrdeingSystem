using OnlineFoodOrdering.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrdering.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        
        public OrderStatus OrderStatus { get; set; }

        public double OrderTotalAmount { get; set; }

        public string OrderAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderPlacedDate { get; set; }

        public ICollection<OrderDetail> OrderFoodItems { get; set; }
    }
}