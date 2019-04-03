using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBasketApp.Models
{
    public class MyBasketRepo
    {
        MyBasketDataContext context = new MyBasketDataContext();

        public List<Brand> GetAllBrands()
        {
            return context.Brands.ToList();
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            return context.Products
                .Where(p => p.BrandID == brandId)
                .ToList();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return context.Products
                .Where(p => p.CategoryID == categoryId)
                .ToList();
        }

        public Product GetProductById(int productId)
        {
            return context.Products.First(p => p.ID == productId);
        }

        public void AddOrder(Order order)
        {
            context.Orders.InsertOnSubmit(order);
            context.SubmitChanges();
        }

        public void AddNewCustomer(Customer customer)
        {
            context.Customers.InsertOnSubmit(customer);
            context.SubmitChanges();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return context.Customers.First(c => c.Email == email);
        }

    }
}