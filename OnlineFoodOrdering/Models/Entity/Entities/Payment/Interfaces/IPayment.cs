using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrdering.Models.Entity.Entities.Payment.Interfaces
{
    public interface IPayment
    {
       void Pay(int amount);
    }
}
