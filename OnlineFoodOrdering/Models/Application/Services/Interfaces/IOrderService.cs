using OnlineFoodOrdering.Models.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrdering.Models.Application.Services.Interfaces
{
    public interface IOrderService
    {
        void ProcessOrder(ShoppingCart shoppingCart, OrderRequestViewModel orderDetails);
        CustomerOrdersViewModel GetAllOrders();
    }
}
