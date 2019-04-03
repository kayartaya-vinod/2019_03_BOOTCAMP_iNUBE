using MyBasketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBasketApp.Controllers
{
    public class CustomerController : Controller
    {
        MyBasketRepo repo = new MyBasketRepo();

        public ActionResult Login()
        {
            return View(new Customer());
        }

        [HttpPost]
        public ActionResult Login(Customer customer, string ReturnUrl )
        {
            Customer cust = repo.GetCustomerByEmail(customer.Email);
            if (cust.Password.Equals(customer.Password))
            {
                HttpContext.Session["customer"] = cust;
                FormsAuthentication.SetAuthCookie(customer.Email, false);
                return Redirect(ReturnUrl == null ? "/" : ReturnUrl);
            }
            return View(customer);
        }

        public ActionResult Register()
        {
            return View(new Customer());
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.AddNewCustomer(customer);
                HttpContext.Session["customer"] = customer;
                FormsAuthentication.SetAuthCookie(customer.Email, false);
                return Redirect("/");
            }
            return View(customer);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}