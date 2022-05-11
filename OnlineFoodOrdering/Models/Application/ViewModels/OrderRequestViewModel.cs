using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.Application.ViewModels
{
    public class OrderRequestViewModel
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public int ShoppingCartId { get; set; }
    }
}