using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrdering.Models.DataBase;
using System.Data.Entity;
using OnlineFoodOrdering.ViewModels;
using OnlineFoodOrdering.Services;
using OnlineFoodOrdering.Models;

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