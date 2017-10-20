using DataServiceProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{

    [Route("/api/products")]
    public class ProductsController : Controller
    {
        private DataService _dataService;
        public ProductsController(DataService dataService)
        {
            _dataService = dataService;

        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }






    }
}

