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


namespace WebService.Controllers
{
    [Route("api/questions")]
    public class QuestionsControllers : CustomeController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public QuestionsControllers(IRepository _repository, IMapper mapper)
        {
            this._repository = _repository;
            this._mapper = mapper;
        }

        [HttpGet(Name = nameof(GetQuestions))]
        public IActionResult GetQuestions(int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountQuestions();
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetQuestions(page, pageSize)
                .Select(x => new QuestionModel
                {
                    Url = Url.Link(nameof(QuestionController.GetQuestionById), new { id = x.Id }),
                    UserName = x.UserInfo.OwnerUserDisplayName,
                    CreationDate = x.CreationDate,
                    Score = x.Score,
                    Title = x.Title,
                    Body = x.Body,
                    UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.OwnerUserId }),
                    // AcceptedAnswerUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.OwnerUserId }),
                      AnswersUrl = Url.Link(nameof(QuestionAnswersController.GetAnswersByQuestionId), new { id = x.Id }),
                    CommentsUrl = Url.Link(nameof(QuestionCommentsController.GetCommentsByQuestionId), new { id = x.Id })

        });

            var result = new
            {
                Total = total,
                Pages = totalPages,
                Page = page,
                Prev = Link(nameof(GetQuestions), page, pageSize, -1, () => page > 0),
                Next = Link(nameof(GetQuestions), page, pageSize, 1, () => page < totalPages - 1),
                Url = Link(nameof(GetQuestions), page, pageSize),
                Data = data
            };

            return Ok(result);
        }



    }
}
