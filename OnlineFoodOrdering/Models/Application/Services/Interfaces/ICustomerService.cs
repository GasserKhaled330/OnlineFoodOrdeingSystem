using OnlineFoodOrdering.Models.Application.ViewModels;
using OnlineFoodOrdering.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrdering.Models.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Customers { get; }
        IEnumerable<UserAccount> CustomerAccounts { get; }
        void SaveCustomer(Customer customer);
        void SaveCustomerAccountAndAddingRole(UserAccount customerAccount);
        bool IsCustomerAlreadyExist(UserAccount customerAccount);
        CustomerOrdersViewModel GetCustomerOrders();
        CustomerAccountsViewModel GetAllUsers();
    }
}
