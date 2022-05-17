using OnlineFoodOrdering.Models.Application.Services.Interfaces;
using OnlineFoodOrdering.Models.Application.ViewModels;
using OnlineFoodOrdering.Models.Entity;
using OnlineFoodOrdering.Models.Infrastructure;
using System;
using System.Linq;

namespace OnlineFoodOrdering.Models.Application.Services
{
    public class OrderProcessor : IOrderService
    {
        private ApplicationDbContext _appDbContext;

        public OrderProcessor()
        {
            _appDbContext = new ApplicationDbContext();
        }

        public void ProcessOrder(ShoppingCart shoppingCart, OrderRequestViewModel orderDetails)
        {
            // get cart items to store it in orderDetails table
            var shoppingCartItems = shoppingCart.GetShoppingCartItems();
            
            //get customer id
            var CustomerId = (from userAccount in _appDbContext.UserAccounts
                              where userAccount.UserName == shoppingCart.CartCustomerUserName
                              select userAccount.Id).Single();

            //Create Order
            Order order = new Order
            {
                CustomerId = CustomerId,
                OrderStatus = OrderStatus.New,
                OrderTotalAmount = shoppingCart.TotalPrice,
                OrderAddress = orderDetails.Address,
                OrderPlacedDate = DateTime.Now,
            };

            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    FoodItemId = item.FoodItem.id,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                };
                
                _appDbContext.OrderDetails.Add(orderDetail);

                _appDbContext.SaveChanges();
            }
            
        }

        public CustomerOrdersViewModel GetAllOrders()
        {
            var orders = _appDbContext.Orders.ToList();
            var orderDetails = _appDbContext.OrderDetails.ToList();
            var customerOrder = new CustomerOrdersViewModel
            {
                Orders = orders,
                OrderDetails = orderDetails
            };
            return customerOrder;
        }
    }
}