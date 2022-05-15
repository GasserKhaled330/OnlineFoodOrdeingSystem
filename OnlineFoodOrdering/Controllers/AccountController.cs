using OnlineFoodOrdering.Models;
using OnlineFoodOrdering.Models.Application.Services;
using OnlineFoodOrdering.Models.Application.Services.Interfaces;
using OnlineFoodOrdering.Models.Entity;
using OnlineFoodOrdering.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineFoodOrdering.Controllers
{
    public class AccountController : Controller
    {
        private ICustomerService customerService = new CustomerService();
        
        UsersRoleProvider usersRoleProvider;

        IAuthProvider authProvider;

        public AccountController()
        {
            authProvider = new FormsAuthProvider();
            usersRoleProvider = new UsersRoleProvider();
        }
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccountViewModel model,ShoppingCart shoppingCart, string returnUrl)
        {
            
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.UserPassword))
                {
                    if (usersRoleProvider.GetRoleIdForUser(model.UserName) == (int)Role.Admin)
                    {
                        return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                    }
                    else
                    {
                        shoppingCart.MigrateShoppingCartToCurrentUser();
                        return Redirect(returnUrl ?? Url.Action("FoodItemsList", "FoodItem"));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(RegisterViewModel registerCustomer)
        {
            if (ModelState.IsValid)
            {
                if (customerService.IsCustomerAlreadyExist(registerCustomer.UserAccount))
                {
                    ViewBag.Message = "Email Already Registered. Please Try Again With Another Email";
                    return View();
                }
                else
                {
                    customerService.SaveCustomer(registerCustomer.Customer);
                    customerService.SaveCustomerAccountAndAddingRole(registerCustomer.UserAccount);
                    return RedirectToAction("FoodItemsList","FoodItem");
                }
                
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}