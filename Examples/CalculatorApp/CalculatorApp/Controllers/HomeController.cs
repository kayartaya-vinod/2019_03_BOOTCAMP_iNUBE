using CalculatorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        CalculatorService service = new CalculatorService();

        public ActionResult Index()
        {
            return View(service.ResultMessages);
        }
        [HttpPost]
        public ActionResult Index(string num1, string num2, string op)
        {
            service.PerformOperation(num1, num2, op);
            return View(service.ResultMessages);
        }
    }
}