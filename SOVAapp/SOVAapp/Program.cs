﻿using System;
using DataService.DataAccessLayer;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
namespace DataService
{
    public class Program 
    {
        private const string QuestionsApi = "http://localhost:5001/api/question";
        private const string UserApi = "http://localhost:5001/api/user";
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

           // rep.AddSearchHistory("whats your name");

         //   Console.WriteLine(rep.RemoveMarking(9033));
            Console.WriteLine(rep.GetAnnotationsByMarkingId(372865).ToList().Last().To);
            Console.ReadLine();
        }
    }
}


     