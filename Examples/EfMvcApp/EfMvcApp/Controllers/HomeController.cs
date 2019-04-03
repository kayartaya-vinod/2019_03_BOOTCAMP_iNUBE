using EfMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfMvcApp.Controllers
{
    public class HomeController : Controller
    {
        MyBasketRepo repo = new MyBasketRepo();

        public ActionResult Index()
        {
            return View(repo.GetAllProducts());
        }
        public ActionResult AddNewProduct()
        {
            ViewBag.Brands = repo.GetAllBrands();
            ViewBag.Categories = repo.GetAllCategories();
            return View(new Product());
        }
        [HttpPost]
        public ActionResult AddNewProduct(Product product)
        {
            repo.AddNewProduct(product);
            return RedirectToAction("Index");
        }
    }
}