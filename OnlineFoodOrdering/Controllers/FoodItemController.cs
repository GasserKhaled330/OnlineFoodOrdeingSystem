using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrdering.Models;
using OnlineFoodOrdering.Models.Application.Interfaces;
using OnlineFoodOrdering.Models.Application.Services;
using OnlineFoodOrdering.Models.Application.ViewModels;
using OnlineFoodOrdering.Services;

namespace OnlineFoodOrdering.Controllers
{
 
    public class FoodItemController : Controller
    {
        private IFoodItemService FoodItemService = new FoodItemService();
        public int PageSize = 6;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FoodItemsList(string category, int page = 1)
        {
            
            FoodItemsListViewModel model = new FoodItemsListViewModel
            {
                FoodItems = FoodItemService.FoodItems
                .Where(p => category == null || p.Category.name == category)
                .OrderBy(p => p.id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                            FoodItemService.FoodItems.Count() : 
                            FoodItemService.Categories.Where(c => c.name == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int Id)
        {
            FoodItem foodItem = FoodItemService.FoodItems
                            .FirstOrDefault(p => p.id == Id);
            if (foodItem != null)
            {
                return File(foodItem.ImageData, foodItem.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}