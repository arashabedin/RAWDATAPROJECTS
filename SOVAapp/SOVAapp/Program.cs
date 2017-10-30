using System;
using DataService.DataAccessLayer;

namespace DataService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Repositorybody rep = new Repositorybody();

            Console.WriteLine(rep.CountUserCustomeFields());
            Console.ReadLine();
        }
    }
}
