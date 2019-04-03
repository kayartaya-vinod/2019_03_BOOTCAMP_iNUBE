using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactsMvcApp.Models;

namespace ContactsMvcApp.Controllers
{
    public class HomeController : Controller
    {
        ContactsRepo repo = new ContactsRepo();

        // GET: Home
        public ActionResult Index()
        {
            return View(new Contact());
        }

        [HttpPost]
        [ActionName("Index")] 
        // It's a good practice to keep the name of the action method equals to name of the action URL
        public ActionResult AddNewContact(Contact contact)
        {
            repo.AddNewContact(contact);
            return RedirectToAction("Index"); // client-side redireaction
        }

        public ActionResult ViewAll()
        {
            List<Contact> list = repo.GetAllContacts();
            return View(list);
        }

        public ActionResult Delete(int id)
        {
            repo.DeleteContact(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Contact c1 = repo.GetContactById(id);
            return View("Index", c1);
        }

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            repo.UpdateContact(contact);
            return RedirectToAction("Index");
        }
    }
}