using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.Application.ViewModels
{
    public class FoodItemsListViewModel
    {
        public IEnumerable<FoodItem> FoodItems { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}