using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceProject.Models;
using DataServiceProject;

namespace WebService.Controllers
{
    [Route("/api/categories")]
    public class CategoriesController : Controller
    {
        private DataService _dataService;
        public CategoriesController(DataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_dataService.GetCategory());
        }
       

        


    }
}
