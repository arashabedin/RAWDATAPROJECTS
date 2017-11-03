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
    [Route("api/answer/{id}")]
    public class AnswerController : CustomeController
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;


        public AnswerController(IRepository _repository, IMapper mapper)
        {
            this._repository = _repository;
            this._mapper = mapper;

        }

        [HttpGet(Name = nameof(GetAnswerById))]
        public IActionResult GetAnswerById(int Id)
        {

            var Answer = _repository.GetAnswerById(Id);
            if (Answer == null) return NotFound();

            var model = _mapper.Map<AnswerModel>(Answer);
            model.UserName = Answer.UserInfo.DisplayName;
            model.Url = Url.Link(nameof(GetAnswerById), new { id = Answer.Id });
            model.UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = Answer.OwneruserId });
            model.QuestionUrl = Url.Link(nameof(QuestionController.GetQuestionById), new { id = Answer.ParentId });
         //   model.CommentsUrl = Url.Link(nameof(CommentController.GetCommentsByAnswerId), new { Qid ,id = Answer.Id});
            return Ok(model);
        }




    }
}
