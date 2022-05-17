
using OnlineFoodOrdering.Models;
using OnlineFoodOrdering.Models.Application.Services;
using OnlineFoodOrdering.Models.Application.Services.Interfaces;
using OnlineFoodOrdering.Models.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodOrdering.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private IOrderService orderProcessor;
        private CustomerService customerService;
        public OrderController()
        {
            orderProcessor = new OrderProcessor();
            customerService = new CustomerService();
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View(new OrderRequestViewModel());
        }

        [HttpPost]
        public ActionResult Checkout(ShoppingCart shoppingCart, OrderRequestViewModel OrderDetails)
        {
            if (shoppingCart.CartItemsCount == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(shoppingCart, OrderDetails);
                shoppingCart.ClearShoppingCartItems();
                return View("Completed");
            }
            else
            {
                return View(OrderDetails);
            }
        }

        public ActionResult MyOrders()
        {
            var customerOrders = customerService.GetCustomerOrders();
            return View(customerOrders);
        }

    }
}