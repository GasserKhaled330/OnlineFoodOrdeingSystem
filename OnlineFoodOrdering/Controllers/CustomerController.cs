using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineFoodOrdering.Models;
using OnlineFoodOrdering.Services;

namespace OnlineFoodOrdering.Controllers
{
   
    public class CustomerController : Controller
    {
        private DatabaseServices db; 

 
        public CustomerController()
        {
            db = new DatabaseServices();
        }


        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {
           var DbCustomer = db.fetchCustumerByEmailAndPassword(customer.email, customer.password);
            if (DbCustomer != null)
            {
                Session["customer"] = DbCustomer;
                return RedirectToAction("profile","Customer");
            }
            else
                return RedirectToAction("login","Customer");

        }

        public ActionResult profile() {
            if (Session["customer"] == null)
                return Content("Session has Expired, Please Login Again");

                return View();
        }

    }
}