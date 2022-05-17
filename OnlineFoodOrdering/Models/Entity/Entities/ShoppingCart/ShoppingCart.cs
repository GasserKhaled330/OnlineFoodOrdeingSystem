using OnlineFoodOrdering.Models.Application.Interfaces;
using OnlineFoodOrdering.Models.Application.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        public string CartCustomerUserName { get; set; }//which is will be equal to customer user name

        IShoppingCartService cartService = new ShoppingCartService();

        public double TotalPrice
        {
            get { return GetShoppingCartItems().Sum(c => c.Quantity * c.FoodItem.price); }
        }
        public int CartItemsCount
        {
            get { return GetShoppingCartItems().Count(); }
        }

        public List<CartItem> GetShoppingCartItems()
        { 
            return cartService.CartItems.Where(
                c => c.ShoppingCart.Id == this.Id).ToList();
        }

        public List<ShoppingCart> GetShoppingCarts()
        {
            return cartService.GetshoppingCarts();
        }

        public void AddCartItem(FoodItem foodItem, int quantity)
        {
            cartService.AddItem(this,foodItem, quantity);
        }

        public void RemoveCartItem(FoodItem foodItem)
        {
            cartService.RemoveItem(foodItem);
        }

        public void MigrateShoppingCartToCurrentUser(string userName)
        {
            cartService.MigrateCart(this, userName);
        }
        
        public void ClearShoppingCartItems()
        {
            cartService.ClearShoppingCart(this);
        }
    }
}