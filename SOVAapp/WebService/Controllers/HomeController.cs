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
                RecommendedQuestions = _Irepository.ShowCustomePosts().Select(i => new CustomPostModel
                {
                    Title = i.Title,
                    Body = i.Body,
                    QuestionUrl = Url.Link(nameof(QuestionController.GetQuestionById), new {Qid = i.PostId }),
                    UsernUrl = Url.Link(nameof(UserController.GetUserByUserId), new { Uid = _Irepository.GetUserByPostId(i.PostId).Id })

                }).ToList()
                //MarkingsUrl =
                //SearchHistoryUrl =
                //CustomeFieldUrl = 

            };
        
      
            
            
            return Ok(model);
        }
    


}
}
