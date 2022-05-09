using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrdering.Models;
using OnlineFoodOrdering.Models.DataBase;
using System.Data.Entity;

namespace OnlineFoodOrdering.Services
{
    public class DatabaseServices : Controller
    {
        private ApplicationDbContext _context; 
        public DatabaseServices() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /*FETCHING LISTS*/
        public IEnumerable<Customer> fetchCustumersList()
        {
            return _context.Customers;
        }

        public IEnumerable<FoodItem> fetchFoodItemsList()
        {
            return _context.FoodItems;
        }
        public List<CartItem> fetchShoppingCartItems(int shoppingCartId)
        {
            return _context.CartItems.Include(f => f.foodItem).Where(c => c.shoppingCartId == shoppingCartId).ToList();
        }


        /*FETCHING BY IDS*/
        public Customer fetchCustumerById(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.id == id);
        }

        public ShoppingCart fetchShoppingCart(int shoppingCartId)
        {
            return _context.ShoppingCarts.SingleOrDefault(s => s.id == shoppingCartId);
        }

        public FoodItem fetchFoodItem(int foodItemId)
        {
            return _context.FoodItems.SingleOrDefault(f => f.id == foodItemId);
        }

        public CartItem fetchCartItem(int shoppingCartId, int foodItemId)
        {
            return _context.CartItems
                 .SingleOrDefault(s => s.shoppingCartId == shoppingCartId
                 && s.foodItemId == foodItemId);
        }






        /*USERID AND PASSWORD FETCHING*/
        public Customer fetchCustumerByEmailAndPassword(string email, string password)
        {
            var dbCustomer = _context.Customers.
                SingleOrDefault(c => c.email==email && c.password==password);

            if (dbCustomer == null)
                return null;
            else
                return dbCustomer;
        }


        /*ADDING TO DB*/
        public void AddCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

    

        /*REMOVING FROM DB*/

        public void RemoveCartItem(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();

        }




        /*shopping cart services*/
        public void UpdateShoppingCartsQuantity(ShoppingCart shoppingCart, List<CartItem> cartItemsList)
        {
            var quantity = 0;
            foreach (var cartItem in cartItemsList)
            {
                quantity += cartItem.quantity;
            }
            shoppingCart.quantity = quantity;

            _context.SaveChanges();

        }

        public void UpdateShoppingCartsTotalPrice(ShoppingCart shoppingCart, List<CartItem> cartItemsList)
        {
            double totalPrice = 0;
            foreach (var cartItem in cartItemsList)
            {
                totalPrice += cartItem.totalPrice;
            }
            shoppingCart.totalPrice = totalPrice;

            _context.SaveChanges();

        }

        public void UpdateCartItemsQtyandTotalPrice(CartItem cartItem, int quantity, double totalPrice)
        {
            cartItem.quantity += quantity;
            cartItem.totalPrice += totalPrice;
            _context.SaveChanges();
        }



    }
}