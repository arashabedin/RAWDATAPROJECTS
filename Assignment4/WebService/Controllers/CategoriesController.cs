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
        // GET api/categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_dataService.GetCategory());
        }
        // GET api/categories/id
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);
            if(category==null)
            {
                return NotFound(category);
            }

            return Ok(category);

        }
        
        // CREATE api/categories
        [HttpPost]
        public IActionResult CreateCategory([FromBody]Category category)
        {
             category = _dataService.CreateCategory(category.Name, category.Description);
          
          return Created($"api/categories/{category}", category);

        }


        // PUT api/categories/id
        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromBody]Category category)
        {

           var updateIt = _dataService.UpdateCategory(category.Id, category.Name, category.Description);
            // if the the result is false
            if (!updateIt)
            {
                return NotFound(updateIt);
            }

            return Ok(updateIt);

        }


        // DELETE api/categories/id




        // DELETE api/categories/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _dataService.DeleteCategory(id);
           
            // if the the result is false
            if (!category)
            {
                return NotFound();
            }

            return Ok( category);
        }




    }
}
