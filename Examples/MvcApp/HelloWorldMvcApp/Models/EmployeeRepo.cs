using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldMvcApp.Models
{
    public class EmployeeRepo
    {
        private static List<Employee> _employees;

        static EmployeeRepo()
        {
            _employees = new List<Employee>()
            {
                new Employee(){Id=101, Name="John Smith", Gender="Male", City="Dallas", Email="john@xmpl.com" },
                new Employee(){Id=221, Name="Jane", Gender="Female", City="Chicago", Email="jane@xmpl.com" },
                new Employee(){Id=123, Name="Martin", Gender="Male", City="Dallas", Email="martin@xmpl.com" },
                new Employee(){Id=451, Name="Miller", Gender="Male", City="Newyork", Email="miller@xmpl.com" }
            };
        }

        // public read-only property for exposing the private _employees
        public List<Employee> Employees
        {
            get { return _employees; }
        }

        public Employee SearchById(int id)
        {
            return _employees.First(emp => emp.Id == id);
        }

        public void AddNewEmployee(Employee employee)
        {
            // need to do validation here also (TDL)
            _employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            // search for the employee's index in the List employees by id
            int index = _employees.FindIndex(e => e.Id == employee.Id);

            // then replace the employee in that index with the argument
            if(index!=-1)
            {
                _employees[index] = employee;
            }
        }

        public void DeleteEmployee(int id)
        {
            int index = _employees.FindIndex(e => e.Id == id);
            if (index != -1)
            {
                _employees.RemoveAt(index);
            }
        }
    }
}