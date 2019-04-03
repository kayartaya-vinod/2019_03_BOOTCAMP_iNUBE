using MyBasketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBasketApp.Controllers
{
    public class HomeController : Controller
    {
        MyBasketRepo repo = new MyBasketRepo();

        public ActionResult Index()
        {
            return View(repo.GetAllProducts());
        }
        public ActionResult ProductsByBrand(int id)
        {
            return View("Index", repo.GetProductsByBrand(id));
        }

        public ActionResult ProductsByCategory(int id)
        {
            return View("Index", repo.GetProductsByCategory(id));
        }
        public ActionResult Brands()
        {
            return View(repo.GetAllBrands());
        }
        public ActionResult Categories()
        {
            return View(repo.GetAllCategories());
        }
        public int AddToCart(int id)
        {
            // check if the "cart" is in the session; if not create a new one
            // and store in the session
            Dictionary<int, LineItem> cart = (Dictionary<int, LineItem>)HttpContext.Session["cart"];
            if (cart is null)
            {
                // this happens when the user clicks on the "Add to cart" first time.
                cart = new Dictionary<int, LineItem>();
                HttpContext.Session["cart"] = cart;
            }

            // check if the product with "id" is in the cart; 
            if (cart.ContainsKey(id))
            {
                // if yes, then increase the quantity of the line-item
                LineItem item = cart[id];
                item.Quantity++;
            }
            else
            {
                // if no, then create and add a new line-item to the cart
                Product p = repo.GetProductById(id);
                LineItem item = new LineItem();
                item.Product = p;
                item.ProductID = p.ID;
                item.UnitPrice = (decimal) p.UnitPrice;
                item.Discount = p.Discount;
                item.Quantity = 1;
                cart[id] = item;
            }
            return cart.Count;
        }

        public ActionResult CartDetails()
        {
            Dictionary<int, LineItem> cart = (Dictionary<int, LineItem>)HttpContext.Session["cart"];
            return View(cart);
        }

        public ActionResult ViewCart()
        {
            Dictionary<int, LineItem> cart = (Dictionary<int, LineItem>)HttpContext.Session["cart"];
            return View(cart.Values);
        }

        public ActionResult RemoveItemFromCart(int id)
        {
            Dictionary<int, LineItem> cart = (Dictionary<int, LineItem>)HttpContext.Session["cart"];
            cart.Remove(id);
            return RedirectToAction("ViewCart");
        }

        public ActionResult EmptyCart()
        {
            Dictionary<int, LineItem> cart = (Dictionary<int, LineItem>)HttpContext.Session["cart"];
            cart.Clear();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult PlaceOrder()
        {
            Order order = new Order();
            Customer loggedInUser = (Customer) HttpContext.Session["customer"];
            order.CustomerID = loggedInUser.ID;
            order.OrderDate = DateTime.Now;
            order.Status = "PENDING";

            
            //// add all items from the cart to this new order
            Dictionary<int, LineItem> cart = (Dictionary<int, LineItem>)HttpContext.Session["cart"];
            
            // for ViewOrderDetails page
            List<LineItem> itemList = new List<LineItem>();
            decimal? total = 0;

            foreach (LineItem item in cart.Values)
            {
                LineItem li = new LineItem();
                li.ProductID = item.ProductID;
                li.Quantity = item.Quantity;
                li.UnitPrice = item.UnitPrice;
                li.Discount = item.Discount;

                total += (item.Quantity * item.UnitPrice * (100 - item.Discount) / 100);

                // ONE-TO-MANY association; 
                // adding order to DB will automatically add all LineItems to DB also.
                order.LineItems.Add(li);

                itemList.Add(item);
            }
            repo.AddOrder(order);



            cart.Clear();

            TempData["order"] = order;
            TempData["items"] = itemList;
            TempData["total"] = total;

            return RedirectToAction("ViewOrderDetails", "Home");
        }

        public ActionResult ViewOrderDetails()
        {
            return View();
        }
    }
}