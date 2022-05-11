using System.Web.Mvc;
using OnlineFoodOrdering.Models;
using OnlineFoodOrdering.Services;

namespace OnlineFoodOrdering.Controllers
{
    public class CartItemController : Controller
    {
        private DatabaseServices db;
        public CartItemController()
        {
            db = new DatabaseServices();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CartItemDetails(int foodItemId)
        {
            var fooditem = db.fetchFoodItem(foodItemId);
            return View(fooditem);
        }


        public ActionResult ModifyCartItem(int cartId, int foodItemId, int quantity)
        {
            AddCartItem(cartId, foodItemId, quantity);
            return RedirectToAction("FoodItemsList", "FoodItem");
        }


        [HttpPost]
        public void AddCartItem(int cartId, int foodItemId, int quantity)
        {
            var dbShoppingCart = db.fetchShoppingCart(cartId);
            var dbFoodItem = db.fetchFoodItem(foodItemId);
            var dbCartItem = db.fetchCartItem(cartId, foodItemId);

            if (dbCartItem != null)
                db.UpdateCartItemsQtyandTotalPrice(dbCartItem, quantity, quantity * dbFoodItem.price);
            else
            {
                CartItem cartItem = new CartItem()
                {
                    foodItemId = dbFoodItem.id,
                    foodItem = dbFoodItem,
                    shoppingCartId = dbShoppingCart.id,
                    shoppingCart = dbShoppingCart,
                    quantity = quantity,
                    totalPrice = dbFoodItem.price * quantity
                };
                db.AddCartItem(cartItem);
            }
        }

        [HttpPost]
        public void RemoveCartItem(int cartId, int foodItemId, int quantity )
        {
            var dbShoppingCart = db.fetchShoppingCart(cartId);
            var dbFoodItem = db.fetchFoodItem(foodItemId);
            var dbCartItem = db.fetchCartItem(cartId, foodItemId);

            if (dbCartItem != null)
                db.UpdateCartItemsQtyandTotalPrice(dbCartItem, -quantity, quantity  * -dbFoodItem.price);

            if (dbCartItem.quantity <= 0)
            {
                db.RemoveCartItem(dbCartItem);
            }
              
        }


    }
}