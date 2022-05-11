using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrdering.Models.Application.Interfaces
{
    public interface IShoppingCart
    {
        ShoppingCart Get(int id);
        ShoppingCart Create(int userId);
        void AddItem(int shoppingCartId, int foodItemId);
        ShoppingCart RemoveItem(int shoppingCartId, int foodItemId);
        bool MarkAsResolved(int shoppingCartId);
    }
}
