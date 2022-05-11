using OnlineFoodOrdering.Models.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrdering.Models.Application.Interfaces
{
    interface IOrderService
    {
        IEnumerable<Order> Orders { get; }
        Order CreateOrder(OrderRequestViewModel orderInfo);
        bool MarkOrderAsPaid(int orderId);
    }
}
