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
    [Route("api")]
    public class QuestionController : CustomeController
    { 
        private readonly IRepository _repository;
    private readonly IMapper _mapper;


    public QuestionController(IRepository _repository, IMapper mapper)
    {
        this._repository = _repository;
        this._mapper = mapper;

    }
        //Get All Questions
        [HttpGet("questions", Name = nameof(GetQuestions))]
        public IActionResult GetQuestions(int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountQuestions();
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetQuestions(page, pageSize)
                .Select(x => new QuestionModel
                {
                    Url = Url.Link(nameof(QuestionController.GetQuestionById), new { Qid = x.Id }),
                    UserName = x.UserInfo.OwnerUserDisplayName,
                    CreationDate = x.CreationDate,
                    Score = x.Score,
                    Title = x.Title,
                    Body = x.Body,
                    Tags = _repository.GetPostTagsByPostId(x.Id).Select(t =>  t.Tag.Tag ).ToList(),
                    UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { Uid = x.OwnerUserId }),
                    AcceptedAnswerUrl = Url.Link(nameof(AnswerController.GetAnswersByQuestionId), new { Qid = x.Id, Aid = x.AcceptedAnswerId }),
                    AnswersUrl = Url.Link(nameof(AnswerController.GetAnswersByQuestionId), new { Qid = x.Id }),
                    CommentsUrl = Url.Link(nameof(CommentController.GetCommentsByQuestionId), new { Qid = x.Id })

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


        // Get Question by Id

        [HttpGet("questions/{Qid}", Name = nameof(GetQuestionById))]
    public IActionResult GetQuestionById(int Qid)
    {

        var Question = _repository.GetQuestionById(Qid);
        if (Question == null) return NotFound();

        var model = _mapper.Map<QuestionModel>(Question);
        model.UserName = Question.UserInfo.DisplayName;
        model.Tags = _repository.GetPostTagsByPostId(Qid).Select(t => t.Tag.Tag).ToList();
        model.Url = Url.Link(nameof(GetQuestionById), new { Qid = Question.Id });
        model.UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { Uid = Question.OwneruserId });
        model.AcceptedAnswerUrl = Url.Link(nameof(AnswerController.GetAnswerById), new { id = Question.AcceptedAnswerId });
        model.AnswersUrl = Url.Link(nameof(AnswerController.GetAnswersByQuestionId), new { Qid = Question.Id });
        model.CommentsUrl = Url.Link(nameof(CommentController.GetCommentsByQuestionId), new { Qid = Question.Id }); 
        return Ok(model);
    }

        // Questions of A user
        [HttpGet("users/{Uid}/questions", Name = nameof(GetQuestionsByUserId))]
        public IActionResult GetQuestionsByUserId(int Uid, int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountQuestionsByUserId(Uid);
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetQuestionsByUserID(Uid, page, pageSize)
                .Select(x => new QuestionModel
                {
                    Url = Url.Link(nameof(QuestionController.GetQuestionById), new { Qid = x.Id }),
                    UserName = x.UserInfo.DisplayName,
                    CreationDate = x.CreationDate,
                    Score = x.Score,
                    Title = x.Title,
                    Body = x.Body,
                    Tags = _repository.GetPostTagsByPostId(x.Id).Select(t => t.Tag.Tag).ToList(),
                    UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { Uid = x.OwneruserId }),
                    AcceptedAnswerUrl = Url.Link(nameof(AnswerController.GetAnswerById), new { id = x.AcceptedAnswerId }),
                    AnswersUrl = Url.Link(nameof(AnswerController.GetAnswersByQuestionId), new { Qid = x.Id }),
                    CommentsUrl = Url.Link(nameof(CommentController.GetCommentsByQuestionId), new { Qid = x.Id })

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
