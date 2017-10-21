using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceProject.Models;
using DataServiceProject;

namespace WebService.Dto
{
    public class ProductsDto 
    {

        public int Id { get; set; }
        public String Name { get; set; }
        public String ProductName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
