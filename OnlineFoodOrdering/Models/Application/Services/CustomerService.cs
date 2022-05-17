﻿using OnlineFoodOrdering.Models.Application.Services.Interfaces;
using OnlineFoodOrdering.Models.Application.ViewModels;
using OnlineFoodOrdering.Models.Entity;
using OnlineFoodOrdering.Models.Infrastructure;
using OnlineFoodOrdering.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrdering.Models.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _appDbContext;

        public CustomerService()
        {
            _appDbContext = new ApplicationDbContext();
        }

        public IEnumerable<Customer> Customers
        {
            get { return _appDbContext.Customers; }
        }

        public IEnumerable<UserAccount> CustomerAccounts
        {
            get { return _appDbContext.UserAccounts; }
        }


        public void SaveCustomer(Customer customer)
        {
            if (customer != null)
            {       
                _appDbContext.Customers.Add(customer);
                _appDbContext.SaveChanges();
            }
        }

        public void SaveCustomerAccountAndAddingRole(UserAccount customerAccount)
        {
            
            if (customerAccount != null)
            {
                //Adding Customer Account
                _appDbContext.UserAccounts.Add(customerAccount);
                _appDbContext.SaveChanges();
                //Adding Role To Customer
                UserRolesMapping userRolesMapping = new UserRolesMapping
                {
                    userID = customerAccount.Id,
                    roleID = (int)Role.Customer
                };

                _appDbContext.UserRolesMappings.Add(userRolesMapping);
                _appDbContext.SaveChanges();
            }
        }

        public bool IsCustomerAlreadyExist(UserAccount customerAccount)
        {
            var isExist = _appDbContext.UserAccounts
                            .SqlQuery("SELECT UserName FROM UserAccounts Where UserName = @customerAccount.UserName");
            if (isExist != null)
            {
                return true;
            }
            return false;
        }

        public CustomerOrdersViewModel GetCustomerOrders()
        {
            var customerId = (from userAccount in _appDbContext.UserAccounts
                              where userAccount.UserName == HttpContext.Current.User.Identity.Name
                              select userAccount.Id).Single();

            var orders = _appDbContext.Orders.Where(o => o.CustomerId == customerId).ToList();
            var orderDetails = _appDbContext.OrderDetails.ToList();
            var customerOrder = new CustomerOrdersViewModel
            {
                Orders = orders,
                OrderDetails = orderDetails
            };
            return customerOrder;
        }

        public CustomerAccountsViewModel GetAllUsers()
        {
            var users = _appDbContext.Customers.ToList();
            var userAccounts = _appDbContext.UserAccounts.ToList();

            var customerAccounts = new CustomerAccountsViewModel
            {
                Customers = users,
                UserAccounts = userAccounts
            };
            return customerAccounts;
        }
    }
}