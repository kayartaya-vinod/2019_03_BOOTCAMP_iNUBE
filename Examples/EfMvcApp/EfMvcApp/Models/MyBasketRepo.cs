using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfMvcApp.Models
{
    public class MyBasketRepo
    {
        TrainingEntities context = new TrainingEntities();

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }
        public List<Brand> GetAllBrands()
        {
            return context.Brands.ToList();
        }
        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
        public void AddNewProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
    }
}