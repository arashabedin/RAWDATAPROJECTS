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

                ds.DeleteCategory(14);
                Console.WriteLine(db.Categories.Count());
            Console.ReadLine();

            }
        }
    }
}

