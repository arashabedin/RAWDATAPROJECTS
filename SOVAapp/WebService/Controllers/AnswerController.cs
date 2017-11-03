﻿using Microsoft.AspNetCore.Mvc;
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
    public class AnswerController : CustomeController
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;


        public AnswerController(IRepository _repository, IMapper mapper)
        {
            this._repository = _repository;
            this._mapper = mapper;

        }
        [HttpGet("questions/{Qid}/answers", Name = nameof(GetAnswersByQuestionId))]
        public IActionResult GetAnswersByQuestionId(int Qid, int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountAnswersByQuestionId(Qid);
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetAllAnswersByQuestionId(Qid, page, pageSize)
                .Select(x => new AnswerModel
                {
                    Url = Url.Link(nameof(GetAnswerById), new { Qid = x.ParentId , Aid = x.Id}),
                    UserName = x.UserInfo.DisplayName,
                    CreationDate = x.CreationDate,
                    Score = x.Score,
                    Body = x.Body,
                    QuestionUrl = Url.Link(nameof(QuestionController.GetQuestionById), new { id = x.ParentId }),
                    UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.OwneruserId }),
                    CommentsUrl = Url.Link(nameof(CommentController.GetCommentsByAnswerId), new { Qid = x.ParentId, Aid = x.Id }),
                });

            var result = new
            {
                Total = total,
                Pages = totalPages,
                Page = page,
                Prev = Link(nameof(GetAnswersByQuestionId), page, pageSize, -1, () => page > 0),
                Next = Link(nameof(GetAnswersByQuestionId), page, pageSize, 1, () => page < totalPages - 1),
                Url = Link(nameof(GetAnswersByQuestionId), page, pageSize),
                Data = data
            };

            return Ok(result);
        }




        [HttpGet("questions/{Qid}/answers/{Aid}", Name = nameof(GetAnswerById))]
        public IActionResult GetAnswerById(int Aid)
        {

            var Answer = _repository.GetAnswerById(Aid);
            if (Answer == null) return NotFound();

            var model = _mapper.Map<AnswerModel>(Answer);
            model.UserName = Answer.UserInfo.DisplayName;
            model.Url = Url.Link(nameof(GetAnswerById), new { Aid = Answer.Id });
            model.UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = Answer.OwneruserId });
            model.QuestionUrl = Url.Link(nameof(QuestionController.GetQuestionById), new { id = Answer.ParentId });
         //   model.CommentsUrl = Url.Link(nameof(CommentController.GetCommentsByAnswerId), new { Qid ,id = Answer.Id});
            return Ok(model);
        }


        [HttpGet("users/{Uid}/answers", Name = nameof(GetAnswersByUserId))]
        public IActionResult GetAnswersByUserId(int Uid, int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountAnswersByUserId(Uid);
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetAllAnswersByUserId(Uid, page, pageSize)
                .Select(x => new AnswerModel
                {
                    Url = Url.Link(nameof(GetAnswerById), new { Qid = x.ParentId, Aid = x.Id }),
                    UserName = x.UserInfo.DisplayName,
                    CreationDate = x.CreationDate,
                    Score = x.Score,
                    Body = x.Body,
                    QuestionUrl = Url.Link(nameof(QuestionController.GetQuestionById), new { Qid = x.ParentId }),
                    UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.OwneruserId }),
                    CommentsUrl = Url.Link(nameof(CommentController.GetCommentsByAnswerId), new { Qid = x.ParentId, Aid = x.Id }),
                });

            var result = new
            {
                Total = total,
                Pages = totalPages,
                Page = page,
                Prev = Link(nameof(GetAnswersByQuestionId), page, pageSize, -1, () => page > 0),
                Next = Link(nameof(GetAnswersByQuestionId), page, pageSize, 1, () => page < totalPages - 1),
                Url = Link(nameof(GetAnswersByQuestionId), page, pageSize),
                Data = data
            };

            return Ok(result);
        }



    }
}
