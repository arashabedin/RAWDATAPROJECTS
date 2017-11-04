using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;
using DataService.DataAccessLayer;
using AutoMapper;
using Microsoft.AspNetCore.Routing;

namespace WebService.Controllers
{
    [Route("api/home")]
    public class HomeController : CustomeController
    {
        private readonly IRepository _Irepository;
        private IMapper _Imapper;

        public HomeController(IRepository _Irepository, IMapper _Imapper)
        {

            this._Irepository = _Irepository;
            this._Imapper = _Imapper;

        }

        [HttpGet(Name = nameof(GetHomeContents))]
        public IActionResult GetHomeContents()
        {
            HomeModel model = new HomeModel()
            {
                 QuestionsUrl = Url.Link(nameof(QuestionController.GetQuestions), new { }),
                 UsersUrl = Url.Link(nameof(UserController.GetUsers), new { }),
                //MarkingsUrl =
                //SearchHistoryUrl =
                //CustomeFieldUrl = 
                //RecommendedQuestions =
            };
            
            return Ok(model);
        }


    }
}
