using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DataAccessLayer;
using DataService.DTO;
using System.Web.Http.Routing;
using WebService.Util;
using WebService.Models;
using AutoMapper;

namespace WebService.Controllers
{
    [Route("api/Users/{id}")]
    public class UserInfoController: Controller
    {

    
         private readonly IRepository _repository;
         private readonly IMapper _mapper;

        public UserInfoController(IRepository _repository, IMapper mapper)
        {
        this._repository = _repository;
           this._mapper = mapper;
        }
        [HttpGet(Name = nameof(GetUserByUserId))]
        public IActionResult GetUserByUserId(int Id)
    {

            var User = _repository.GetUserById(Id);
            if (User == null) return NotFound();

            var model = _mapper.Map<UserInfoModel>(User);
            model.Url = Url.Link(nameof(GetUserByUserId), new { id = User.Id });


            return Ok(model);
        }


    // Helpers 

    private string Link(string route, int page, int pageSize, int pageInc = 0, Func<bool> f = null)
    {
        if (f == null) return Url.Link(route, new { page, pageSize });

        return f()
            ? Url.Link(route, new { page = page + pageInc, pageSize })
            : null;
    }

    private static int GetTotalPages(int pageSize, int total)
    {
        return (int)Math.Ceiling(total / (double)pageSize);
    }

    private static void CheckPageSize(ref int pageSize)
    {
        pageSize = pageSize > 50 ? 50 : pageSize;
    }

}
}
