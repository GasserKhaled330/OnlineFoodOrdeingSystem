using OnlineFoodOrdering.Models.Application.Interfaces;
using OnlineFoodOrdering.Models.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrdering.Controllers
{
    public class NavController : Controller
    {
        private IFoodItemService repository = new FoodItemService();

        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Categories
                                                .Select(x => x.name)
                                                .Distinct()
                                                .OrderBy(x => x);
            return PartialView("FlexMenu", categories);
        }
    }
}