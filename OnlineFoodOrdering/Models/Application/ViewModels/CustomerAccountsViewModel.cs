using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.Application.ViewModels
{
    public class CustomerAccountsViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<UserAccount> UserAccounts { get; set; }
    }
}