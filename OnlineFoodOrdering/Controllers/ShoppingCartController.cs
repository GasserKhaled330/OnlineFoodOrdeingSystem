using System.Linq;
using System.Web.Mvc;
using OnlineFoodOrdering.Models;
using OnlineFoodOrdering.Models.Application.Interfaces;
using OnlineFoodOrdering.Models.Application.Services;

namespace OnlineFoodOrdering.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly IFoodItemService FoodItemService = new FoodItemService();

        public ActionResult Index(ShoppingCart shoppingCart)
        {
            
            return View(shoppingCart);
        }

        
        [HttpPost]
        public ActionResult AddItem(ShoppingCart shoppingCart,int Id, int quantity = 1)
        {
            FoodItem foodItem = FoodItemService.FoodItems.FirstOrDefault(p => p.id == Id);
            if (foodItem != null)
            {
                //shoppingCart.MigrateShoppingCartToCurrentUser();
                shoppingCart.AddCartItem(foodItem, quantity);
            }
            return RedirectToAction("Index");
        }

      
        [HttpPost]
        public ActionResult RemoveItem(ShoppingCart shoppingCart,int Id)
        {
            FoodItem foodItem = FoodItemService.FoodItems.FirstOrDefault(p => p.id == Id);
            if (foodItem != null)
            {
                shoppingCart.RemoveCartItem(foodItem);
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult CartSummary(ShoppingCart cart)
        {
            return PartialView(cart);
        }

    }
}