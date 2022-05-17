using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.Entity
{
    public enum Role
    {
        Admin = 1,
        Customer = 2
    }

    public enum OrderStatus
    {
        New = 1,
        InProduction = 2,
        Shipped = 3,
    }
}