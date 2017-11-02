using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DataAccessLayer;
using DataService.DTO;
using System.Web.Http.Routing;
using WebService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Routing;



namespace WebService.Controllers
{

    [Route("api/user/{id}")]

    public class UserController: Controller
    {  
    
         private readonly IRepository _repository;
         private readonly IMapper _mapper;
     

        public UserController(IRepository _repository, IMapper mapper)
        {
        this._repository = _repository;
           this._mapper = mapper;
         
        }
      
       [HttpGet(Name = nameof(GetUserByUserId))]
        public IActionResult GetUserByUserId( int Id)
    {
            
            var User = _repository.GetUserById(Id);
            if (User == null) return NotFound();
           
            var model = _mapper.Map<UserInfoModel>(User);
            model.Url = Url.Link(nameof(GetUserByUserId), new { id = User.Id });
            model.AnswersUrl = Url.Link(nameof(UserAnswersController.GetAnswersByUserId), new { id = User.Id });
            return Ok(model);
        }


    

    }
}
