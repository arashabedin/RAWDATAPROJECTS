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
    [Route("api/Questions/Answer/{id}/comments")]
    public class QAnswerCommentsController : CustomeController
    { 
 private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public QAnswerCommentsController(IRepository _repository, IMapper mapper)
    {
        this._repository = _repository;
        this._mapper = mapper;
    }

    [HttpGet(Name = nameof(GetCommentsByAnswerId))]
    public IActionResult GetCommentsByAnswerId(int Id, int page = 0, int pageSize = 2)
    {
        CheckPageSize(ref pageSize);

        var total = _repository.CountCommentsByPostId(Id);
        var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetCommentsByPostId(Id, page, pageSize)
                .Select(x => new CommentModel
                {
                    Url = Url.Link(nameof(CommentController.GetCommentById), new { Qid = x.CommentId }),
                UserName = x.UserInfo.DisplayName,
                CreationDate = x.CreationDate,
                Score = x.Score,
                Body = x.Body,
                PostUrl = Url.Link(nameof(AnswerController.GetAnswerById), new { id = x.post.Id }),
                UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.User }),
         
                });

        var result = new
        {
            Total = total,
            Pages = totalPages,
            Page = page,
            Prev = Link(nameof(GetCommentsByAnswerId), page, pageSize, -1, () => page > 0),
            Next = Link(nameof(GetCommentsByAnswerId), page, pageSize, 1, () => page < totalPages - 1),
            Url = Link(nameof(GetCommentsByAnswerId), page, pageSize),
            Data = data
        };

        return Ok(result);
    }



}
}