using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataServiceProject.Models;

namespace DataServiceProject
{
    public class DataService
    {
        private readonly NorthwindContext db;
        public DataService()
        {
            db = new NorthwindContext();
        }



        // Category

        public Category GetCategory(int id)
        {


            var category = db.Categories.Where(p => p.Id == id);
            return category.FirstOrDefault();

        }

        public void AddCategory(string name, string description)
        {
            var category = new Category
            {
                Name = name,
                Description = description
            };
            db.Add(category);
            db.SaveChanges();
        }

        public void UpdateCategory(int id, string name)
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
                category.Name = name;
        }

        public void DeleteCategory(int id)
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
                db.Categories.Remove(category);
        }


        // Products
        public Product GetProduct(int id)
        {

            var product = db.Products.Where(p => p.Id == id).FirstOrDefault();
            var Category = db.Categories.Where(c => c.Id == product.CategoryId).FirstOrDefault();
            product.Category = Category;
            return product;


        }

        // Orders
        public List<Order> GetOrders()
        {
            return db.Orders.ToList();
        }

        public Order GetOrder(int id)
        {

            var order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
                order.OrderDetails = db.OrderDetails.Where(z => z.OrderId == id).ToList();
            return order;
        }


        //--------------OrderDetails
        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            //SHOULD BE IMPLEMENTED

            return new List<OrderDetails>();
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            //SHOULD BE IMPLEMENTED

            return new List<OrderDetails>();
        }

    }
}

