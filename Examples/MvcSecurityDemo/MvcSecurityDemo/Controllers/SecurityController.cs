using MvcSecurityDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcSecurityDemo.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Login()
        {
            return View(new SiteUser());
        }

        [HttpPost]
        public ActionResult Login(SiteUser user, string ReturnUrl)
        {
            if (IsValidUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                return Redirect(ReturnUrl == null ? "/" : ReturnUrl);
            }
            return View(user);
        }

        public bool IsValidUser(SiteUser user)
        {
            // typically, this is a DAO's job to check if the
            // user is a valid user based on DB entry;
            return (user.Username.ToLower().Equals("admin") &&
                user.Password.Equals("topsecret"));
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Security/Login");
        }
    }
}