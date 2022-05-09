using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrdering.Services;

namespace OnlineFoodOrdering.Controllers
{
 
    public class FoodItemController : Controller
    {
        private DatabaseServices db = new DatabaseServices();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FoodItemsList()
        {
            var foodlist = db.fetchFoodItemsList().ToList();
            return View(foodlist);
        }

    }
}