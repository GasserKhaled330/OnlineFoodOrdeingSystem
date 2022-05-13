using OnlineFoodOrdering.Models;
using OnlineFoodOrdering.Models.Application.Interfaces;
using OnlineFoodOrdering.Models.Application.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrdering.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IFoodItemService repository = new FoodItemService();
        // GET: Admin
        public ActionResult Index()
        {
            
            return View(repository.FoodItems);
        }

        public ActionResult Edit(int Id)
        {
            FoodItem foodItem = repository.FoodItems
                                .FirstOrDefault(p => p.id == Id);
            ViewBag.CategoryNameDropList = new SelectList(repository.Categories.ToList(), "Id", "Name");
            return View(foodItem);
        }

        [HttpPost]
        
        public ActionResult Edit(FoodItem foodItem, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    foodItem.ImageMimeType = image.ContentType;
                    foodItem.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(foodItem.ImageData, 0, image.ContentLength);
                }
                
                repository.SaveProduct(foodItem);
                TempData["message"] = string.Format("{0} has been saved", foodItem.name);
                
                return RedirectToAction("Index");
            }
   
            return View(foodItem);
        }

        public ViewResult Create()
        {
            ViewBag.CategoryNameDropList = new SelectList(repository.Categories.ToList(), "Id", "Name");
            return View("Edit", new FoodItem());
        }

        [HttpPost]
        
        public ActionResult Delete(int Id)
        {
            FoodItem deletedFoodItem = repository.DeleteProduct(Id);
            if (deletedFoodItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedFoodItem.name);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(Category category)
        {
            repository.SaveFoodCategory(category);
            return RedirectToAction("Index");
        }
    }
}