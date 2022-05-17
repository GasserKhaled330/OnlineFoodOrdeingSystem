using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrdering.Models.Application.Interfaces
{
    public interface IShoppingCartService
    {
        List<ShoppingCart> GetshoppingCarts();
        List<CartItem> CartItems { get; }
        void AddItem(ShoppingCart shoppingCart,FoodItem foodItem, int quantity);
        void RemoveItem(FoodItem foodItem);
        void MigrateCart(ShoppingCart shoppingCart,string userName);
        void ClearShoppingCart(ShoppingCart shoppingCart);
    }
}
