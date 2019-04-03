using MvcAppWithDbData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppWithDbData.Controllers
{
    public class HomeController : Controller
    {
        ShipperRepo repo = new ShipperRepo();

        // GET: Home
        public ActionResult Index()
        {
            return View(new Shipper());
        }

        [HttpGet]
        public ActionResult ListShippers()
        {
            return View(repo.GetAllShippers());
        }
        

        [HttpPost]
        public ActionResult Index(Shipper shipper)
        {
            repo.AddNew(shipper);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Shipper sh = repo.GetAllShippers().First(s => s.ShipperID == id);
            return View("Index", sh);
        }

        [HttpPost]
        public ActionResult Edit(int id, Shipper shipper)
        {
            repo.Update(shipper);
            return RedirectToAction("Index");
        }

        public ActionResult AddNew()
        {
            return RedirectToAction("Index");
        }

        public ActionResult DeleteShipper(int id)
        {
            repo.DeleteShipper(id);
            return RedirectToAction("Index");
        }
    }
}