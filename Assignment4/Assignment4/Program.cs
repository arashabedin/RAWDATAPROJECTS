using System;
using System.Linq;

namespace DataServiceProject
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new NorthwindContext())
            {
                DataService ds = new DataService();
                var products = ds.GetProductByName("RAWDATA");
                Console.WriteLine(products);
            Console.ReadLine();

            }
        }
    }
}

