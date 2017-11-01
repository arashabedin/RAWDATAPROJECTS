using System;
using DataService.DataAccessLayer;
using System.Linq;
namespace DataService
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*  using (var db = new SOVAContext())
              {
                  int x = 1;
                  foreach (var item in db.UserInfo)
                  {


                      db.Entry(item).Reload();
                      db.SaveChanges();

                      Console.WriteLine("done with" + x);
                      x++;

                  }
              }*/
            var rep = new RepositoryBody();

            Console.WriteLine();
            rep.AddUserCustomeField();
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
