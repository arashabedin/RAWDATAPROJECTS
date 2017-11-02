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
    [Route("api/Comment/{id}")]
    public class CommentController : CustomeController
    { 
     private readonly IRepository _repository;
    private readonly IMapper _mapper;


    public CommentController(IRepository _repository, IMapper mapper)
    {
        this._repository = _repository;
        this._mapper = mapper;

    }

    [HttpGet(Name = nameof(GetCommentById))]
    public IActionResult GetCommentById(int Id)
    {

        var Comment = _repository.GetCommentById(Id);
        if (Comment == null) return NotFound();

            var model = new CommentModel();
    
            model.Url = Url.Link(nameof(GetCommentById), new { id = Comment.CommentId });
            model.UserName = Comment.UserInfo.DisplayName;
            model.Score = Comment.Score;
            model.Body = Comment.Body;
            model.CreationDate = Comment.CreationDate;
            model.UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = Comment.User });
            model.PostUrl = Url.Link(nameof(QuestionController.GetQuestionById), new { id = Comment.post.Id });

            return Ok(model);
    }




}
}
