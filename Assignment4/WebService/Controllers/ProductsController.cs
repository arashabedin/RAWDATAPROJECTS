using DataServiceProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Dto;
using DataServiceProject;

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
        // GET api/products/id
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);
            if (product == null)
            {
                return NotFound(product);
            }

            return Ok(product);

        }
        // GET api/products/category/id
        [Route("category/{id}")]
        // [HttpGet("{id}")]
        public IActionResult GetProductByCategory(int id)
        {
            var products = _dataService.GetProductByCategory(id);
      
            if (products.Count == 0)
            {
                return NotFound(products);
            }

            // Passing data through DTO
            List<ProductsDto> newProducts = new List<ProductsDto>();
            foreach (var item in products)
            {
                var dto = new ProductsDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category.Name
                };
                newProducts.Add(dto);
            }

            return Ok(newProducts);

        }



        //  GET api/products/name
        [Route("name/{name}")]
        public IActionResult GetProductByName(String name)
        {
            var products = _dataService.GetProductByName(name).OrderBy(i => i.Id).ToList();
            if (products.Count==0)
            {
                return NotFound(products);
            }
            List<ProductsDto> newProducts = new List<ProductsDto>();
            foreach (var item in products)
            {
                var dto = new ProductsDto()
                {
                    Id = item.Id,
                    ProductName = item.Name,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category.Name
                };
                newProducts.Add(dto);
            }

            return Ok(newProducts);

        }


    }
}

