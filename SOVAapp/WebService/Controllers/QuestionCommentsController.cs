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
    [Route("api/Questions/{id}/comments")]
    public class QuestionCommentsController : CustomeController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public QuestionCommentsController(IRepository _repository, IMapper mapper)
        {
            this._repository = _repository;
            this._mapper = mapper;
        }

        [HttpGet(Name = nameof(GetCommentsByQuestionId))]
        public IActionResult GetCommentsByQuestionId(int Id, int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountCommentsByPostId(Id);
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetCommentsByPostId(Id, page, pageSize)
                .Select(x => new CommentModel
                {
                    Url = Url.Link(nameof(CommentController.GetCommentById), new { id = x.CommentId }),

                    CreationDate = x.CreationDate,
                    Score = x.Score,
                    Body = x.Body,
                    PostUrl = Url.Link(nameof(QuestionController.GetQuestionById), new { id = x.post.Id }),
                    UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.User }),
                    //  CommentsUrl = Url.Link("Comments", new { PostId = x.Comments }),
                });

            var result = new
            {
                Total = total,
                Pages = totalPages,
                Page = page,
                Prev = Link(nameof(GetCommentsByQuestionId), page, pageSize, -1, () => page > 0),
                Next = Link(nameof(GetCommentsByQuestionId), page, pageSize, 1, () => page < totalPages - 1),
                Url = Link(nameof(GetCommentsByQuestionId), page, pageSize),
                Data = data
            };

            return Ok(result);
        }



    }
}