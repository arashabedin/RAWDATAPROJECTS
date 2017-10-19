using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataServiceProject.Models;
using DataServiceProject;
namespace DataServiceProject
{
    public class DataService
    {
        //private readonly  NorthwindContext db;
        public DataService()
        {
       //     db = new NorthwindContext();
        }



        // Category

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

            var product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            var Category = db.Categories.Where(c => c.Id == product.CategoryId).FirstOrDefault();
            product.Category = Category;
            return product;
        }
        
        }

        // Orders
        public List<Order> GetOrders()
        {
        using (var db = new NorthwindContext())
        {

            return db.Orders.ToList();
        }
        }
        

        public Order GetOrder(int id)
        {
        using (var db = new NorthwindContext())
        {
            var order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
                order.OrderDetails = db.OrderDetails.Where(z => z.OrderId == id).ToList();
            return order;
        }
        }


        // OrderDetails
        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            using (var db = new NorthwindContext())
            {

                //SHOULD BE IMPLEMENTED

                return new List<OrderDetails>();
            }
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            using (var db = new NorthwindContext())
            {
                //SHOULD BE IMPLEMENTED

                return new List<OrderDetails>();
            }
        }

    }
}

