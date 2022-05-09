using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.DataBase
{
    public class ApplicationDbContext :DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasOptional(c => c.ShoppingCart)
                  .WithRequired(sc => sc.customer)
                  .WillCascadeOnDelete(true);

            modelBuilder.Entity<Customer>().HasOptional(c => c.address)
                 .WithRequired(a => a.customer)
                 .WillCascadeOnDelete(true);

            modelBuilder.Entity<CartItem>()
                .HasKey(c => new { c.shoppingCartId, c.foodItemId });
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

       public DbSet<Address> Address { get; set; }
       //DbSet<Order> orders { get; set; }
    }
}