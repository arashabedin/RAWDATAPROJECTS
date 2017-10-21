using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataServiceProject.Models;
using DataServiceProject;
using Microsoft.EntityFrameworkCore;

namespace DataServiceProject
{
    public class DataService
    {
        public DataService()
        {

        }



        // Category

            public IList<Category> GetCategory()
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.ToList();
                return category;

            }
        }

        public Category GetCategory(int id)
        {
            using (var db = new NorthwindContext())
            {

                var category = db.Categories.Where(p => p.Id == id).FirstOrDefault();


                return category;

            }
           
        }

        public Category CreateCategory(string name, string description)
        {
            using (var db = new NorthwindContext()) {
                var category = new Category
                {

                Id = db.Categories.Count() + 3,
                    Name = name,
                    Description = description
                };
                db.Add(category);
                db.SaveChanges();

            return category;
            }
        }

    

    public bool UpdateCategory(int id, string name, string description)

    {
            using (var db = new NorthwindContext())
            {

                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                if (category != null) { 
                    category.Name = name;
                    category.Description = description;
                    db.SaveChanges();
                    return true;
                }
                return false;

            }

        }

        public Boolean DeleteCategory(int id)
        {

        using (var db = new NorthwindContext())
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == id);

            if (category != null)
            {
                db.Categories.Remove(category);
                    Console.WriteLine("removed");
                    db.SaveChanges();

                    return true;
            }
            return false;
        }
        }
        


        // Products
        public Product GetProduct(int id)
        {
        using (var db = new NorthwindContext())
        {

            var product = db.Products.Include(x => x.Category).Where(p => p.Id == id).FirstOrDefault();
            // var Category = db.Categories.Where(c => c.Id == product.CategoryId).FirstOrDefault();
           // product.Category = Category;
            return product;
        }
        
        }



        public List<Product> GetProductByCategory(int id)
        {
            using (var db = new NorthwindContext())
            {

                var products = db.Products.Include(x => x.Category).Where(p => p.CategoryId == id).ToList();
                // var Category = db.Categories.Where(c => c.Id == product.CategoryId).FirstOrDefault();
                // product.Category = Category;
                return products;
            }

        }

        public List<Product> GetProductByName(String name)
        {
            using (var db = new NorthwindContext())
            {
                var products = db.Products.Include(x => x.Category).Where(p => p.Name == name).ToList();
                // var Category = db.Categories.Where(c => c.Id == product.CategoryId).FirstOrDefault();
                // product.Category = Category;
                return products;
            }

        }

        // Orders
        public List<Order> GetOrders()
        {
        using (var db = new NorthwindContext())
        {

                var orders = db.Orders.ToList(); 
                return orders;
        }
        }
        

        public Order GetOrder(int id)
        {
            using (var db = new NorthwindContext())
            {
                // Henriks guide on including the child objects
                var order = db.Orders.Include(x => x.OrderDetails).Where(x => x.Id == id).FirstOrDefault();
                if (order != null) { 
                  //  order.OrderDetails = GetOrderDetailsByOrderId(id);
                     return order;
                }
                return null;
        }
        }


        // OrderDetails
        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            using (var db = new NorthwindContext())
            {

                var orderDetails = db.OrderDetails.Include(x => x.Product).Include(x => x.Order).Where(o => o.OrderId == id).ToList();
              /*  foreach (var item in orderDetails)
                {
                  item.Product = GetProduct(item.ProductId);
                    item.Order = GetOrder(item.OrderId);
                }
                */
                return orderDetails;

            }
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            using (var db = new NorthwindContext())
            {
                var orderDetails = db.OrderDetails.Include(x => x.Product).Include(x => x.Order).Where(p => p.ProductId == id).ToList();
              /*  foreach (var item in orderDetails)
                {
                    item.Product = GetProduct(item.ProductId);
                    item.Order = GetOrder(item.OrderId);
                }
                */
                return orderDetails;
            }
        }

    }
}

