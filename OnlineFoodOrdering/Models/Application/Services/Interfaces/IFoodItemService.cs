using System.Collections.Generic;

namespace OnlineFoodOrdering.Models.Application.Interfaces
{
    public interface IFoodItemService
    {
        IEnumerable<FoodItem> FoodItems { get; }
        void SaveProduct(FoodItem foodItem);
        FoodItem DeleteProduct(int foodItemID);
    }
}
