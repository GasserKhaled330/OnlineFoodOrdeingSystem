using OnlineFoodOrdering.Models.Application.Services.Interfaces;
using OnlineFoodOrdering.Models.Entity;
using OnlineFoodOrdering.Models.Infrastructure;
using System.Collections.Generic;

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
                    userID = customerAccount.ID,
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
    }
}