﻿using OnlineFoodOrdering.Models.Application.Interfaces;
using OnlineFoodOrdering.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private ApplicationDbContext _appDbContext;

        public ShoppingCartService()
        {
            _appDbContext = new ApplicationDbContext();
        }


        public List<CartItem> CartItems
        {
            get { return _appDbContext.CartItems.ToList(); }
        }

        public List<ShoppingCart> GetshoppingCarts()
        {
             return _appDbContext.ShoppingCart.ToList(); 
        }

        public void AddItem(ShoppingCart shoppingCart,FoodItem foodItem, int quantity)
        {
            // Retrieve the product from the database.           
            
            CartItem cartItem = _appDbContext.CartItems.SingleOrDefault(
                c => c.FoodItemId == foodItem.id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ShoppingCartId = shoppingCart.Id,
                    FoodItem = _appDbContext.FoodItems.SingleOrDefault(
                   p => p.id == foodItem.id),
                    Quantity = quantity,
                };
                _appDbContext.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }
            _appDbContext.SaveChanges();
        }


        public void RemoveItem(FoodItem foodItem)
        {
            var cartItem = _appDbContext.CartItems.Where(_ => _.FoodItem.id == foodItem.id);
            if (foodItem != null)
            {
                _appDbContext.CartItems.RemoveRange(cartItem);
                _appDbContext.SaveChanges();
            }
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(ShoppingCart shoppingCart,string userName)
        {
            shoppingCart.CartCustomerUserName = userName;
            _appDbContext.ShoppingCart.Add(shoppingCart);
            _appDbContext.SaveChanges();
        }


    }
}