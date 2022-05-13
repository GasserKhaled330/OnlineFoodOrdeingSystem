using OnlineFoodOrdering.Models.Application.Interfaces;
using OnlineFoodOrdering.Models.Infrastructure;
using System.Collections.Generic;

namespace OnlineFoodOrdering.Models.Application.Services
{
    public class FoodItemService : IFoodItemService
    {
        private ApplicationDbContext _appDbContext = new ApplicationDbContext();

        public IEnumerable<FoodItem> FoodItems { 
            get { return _appDbContext.FoodItems; }
        }

        public IEnumerable<Category> Categories
        {
            get { return _appDbContext.Categories; }
        }

        public FoodItem DeleteProduct(int foodItemID)
        {
            FoodItem dbEntry = _appDbContext.FoodItems.Find(foodItemID);
            if (dbEntry != null)
            {
                _appDbContext.FoodItems.Remove(dbEntry);
                _appDbContext.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveProduct(FoodItem foodItem)
        {
            if (foodItem.id == 0)
            {
                _appDbContext.FoodItems.Add(foodItem);
            }
            else
            {
                FoodItem dbEntry = _appDbContext.FoodItems.Find(foodItem.id);
                if (dbEntry != null)
                {
                    dbEntry.name = foodItem.name;
                    dbEntry.description = foodItem.description;
                    dbEntry.price = foodItem.price;
                    dbEntry.CategoryId = foodItem.CategoryId;
                    dbEntry.ImageData = foodItem.ImageData;
                    dbEntry.ImageMimeType = foodItem.ImageMimeType;
                }
            }
            _appDbContext.SaveChanges();
        }

        public void SaveFoodCategory(Category category)
        {
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
        }
    }
}