using System.Web.Mvc;
using OnlineFoodOrdering.ViewModels;
using OnlineFoodOrdering.Services;

namespace OnlineFoodOrdering.Controllers
{
    public class ShoppingCartController : Controller
    {

        private DatabaseServices db;
        public ShoppingCartController()
        {
            db = new DatabaseServices();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowShoppingCart(int shoppingCartId)
        {
            var ShoppingCart = db.fetchShoppingCart(shoppingCartId);
            var CartItemsList = db.fetchShoppingCartItems(shoppingCartId);

            db.UpdateShoppingCartsQuantity(ShoppingCart, CartItemsList);
            db.UpdateShoppingCartsTotalPrice(ShoppingCart, CartItemsList);

            var FilledShoppingCart = new ShopingCartAndCartItemsViewModel()
            {
                shoppingCart = ShoppingCart,
                cartItems = CartItemsList
            };

            return View(FilledShoppingCart);
        }



    }
}