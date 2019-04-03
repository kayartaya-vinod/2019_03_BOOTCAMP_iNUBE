using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMvcApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
    }
}