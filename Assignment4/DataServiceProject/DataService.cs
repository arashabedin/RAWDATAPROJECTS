﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataServiceProject
{

    class DataService 
    {

    public Category GetCategory(int id) { 
            using (var db = new NorthwindContex())
            {

              var category =  db.Categories.Where(p => p.Id == id);
                return category.FirstOrDefault();
            }



        }
        // Products
        public Product GetProduct(int id)
        {
            using (var db = new NorthwindContex())
            {

                var product = db.Products.Where(p => p.Id == id);
                return product.FirstOrDefault();
            }



        }



    }
    }

