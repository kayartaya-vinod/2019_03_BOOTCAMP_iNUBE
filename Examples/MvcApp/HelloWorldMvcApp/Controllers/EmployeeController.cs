using HelloWorldMvcApp.Models;
using System.Web.Mvc;

namespace HelloWorldMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepo repo = new EmployeeRepo();

        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.Title = "Details of an employee";
            ViewBag.Emp = new Employee()
            {
                Id = 1001,
                Name = "Shyam Sundar",
                Email = "shyam@example.com",
                City = "Shimoga"
            };

            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.Emp = repo.SearchById(id);
            return View("Index"); // here "Index" --> "Views/Employee/Index.cshtml"
        }

        // GET http://..../employee/search?name=Vinod+Kumar&city=Bangalore
        public string Search(string name, string city)
        {
            string msg = "Name = " + name + ", city = " + city;
            return msg;
        }

        public ActionResult List()
        {

            ViewBag.Employees = repo.Employees;


            return View();
        }

        // this renders the HTML form for the user to add a new employee
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        // this handles form submission
        //[HttpPost]
        //public ActionResult Add(FormCollection data)
        //{
        //    Employee emp = new Employee();
        //    emp.Id = int.Parse(data["id"]);
        //    emp.Name = data["name"];
        //    emp.Gender = data["gender"];
        //    emp.City = data["city"];
        //    emp.Email = data["email"];
        //    emp.Salary = decimal.Parse(data["salary"]);

        //    repo.AddNewEmployee(emp);

        //    return RedirectToAction("List");
        //}

        //[HttpPost]
        //public ActionResult Add(int id, string name, string gender, string city, string email, decimal salary)
        //{
        //    Employee emp = new Employee();
        //    emp.Id = id;
        //    emp.Name = name;
        //    emp.Gender = gender;
        //    emp.City = city;
        //    emp.Email = email;
        //    emp.Salary = salary;

        //    repo.AddNewEmployee(emp);

        //    return RedirectToAction("List");
        //}

        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            repo.AddNewEmployee(emp);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee emp = repo.SearchById(id);
            if (emp == null)
            {
                return RedirectToAction("List");
            }
            return View(emp); // Here emp --> @Model (in the view)
        }

        public ActionResult Edit(Employee emp)
        {
            // if id in the hidden field has been tampered..
            //Employee empSearched= repo.SearchById(emp.Id);
            //if (empSearched == null)
            //{
            //    return RedirectToAction("List");
            //}

            repo.UpdateEmployee(emp);

            return RedirectToAction("Details", new { id = emp.Id });
        }

        public ActionResult Delete(int id)
        {
            repo.DeleteEmployee(id);
            return View();
        }
    }


}