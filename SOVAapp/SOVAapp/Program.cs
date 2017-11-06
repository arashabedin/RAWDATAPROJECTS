using System;
using DataService.DataAccessLayer;
using System.Linq;
namespace DataService
{
    public class Program 
    {
        private const string QuestionsApi = "http://localhost:5001/api/question/19";
        private const string UsersApi = "http://localhost:5001/api/user";
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
            Helpers helper = new Helpers();
            var (data, statusCode) = helper.GetObject(QuestionsApi);
 

            // Assert.Equal(HttpStatusCode.OK, statusCode);
            //      Assert.Equal(7, data.Count);
            Console.WriteLine(data["url"]);
          
       //     Assert.Equal(164, data.First()["score"]);
       //     Assert.Equal("Anton", data.Last()["userName"]);
       //     Console.WriteLine(rep.RemoveMarking(9033));
      //      Console.WriteLine("done");
       //     Console.ReadLine();

            var rep = new RepositoryBody();

           // rep.AddSearchHistory("whats your name");

         //   Console.WriteLine(rep.RemoveMarking(9033));
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}


     