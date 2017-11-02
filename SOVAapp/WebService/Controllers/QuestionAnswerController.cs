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

namespace WebService.Controllers
{
    [Route("api/{id}/answers")]
    public class QuestionAnswerController : CustomeController
    { 
  private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public QuestionAnswerController(IRepository _repository, IMapper mapper)
    {
        this._repository = _repository;
        this._mapper = mapper;
    }

        [HttpGet(Name = nameof(GetAnswersByQuestionId))]
        public IActionResult GetAnswersByQuestionId(int Id, int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountAnswersByQuestionId(Id);
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetAllAnswersByQuestionId(Id,page, pageSize)
                .Select(x => new AnswerModel
                {
                    Url = Url.Link(nameof(GetAnswersByQuestionId), new { id = x.Id }),
                    Id = x.Id,
                    CreationDate = x.CreationDate,
                    Score = x.Score,
                    Body = x.Body,
                    QuestionUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.OwneruserId }),
                    UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.OwneruserId }),
                  //  CommentsUrl = Url.Link("Comments", new { PostId = x.Comments }),
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
