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
    [Route("api/question/{id}")]
    public class QuestionController : CustomeController
    { 
        private readonly IRepository _repository;
    private readonly IMapper _mapper;


    public QuestionController(IRepository _repository, IMapper mapper)
    {
        this._repository = _repository;
        this._mapper = mapper;

    }

    [HttpGet(Name = nameof(GetQuestionById))]
    public IActionResult GetQuestionById(int Id)
    {

        var Question = _repository.GetQuestionById(Id);
        if (Question == null) return NotFound();

        var model = _mapper.Map<QuestionModel>(Question);
        model.Url = Url.Link(nameof(GetQuestionById), new { id = Question.Id });
        model.UserUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = Question.OwneruserId });
        model.AcceptedAnswerUrl = Url.Link(nameof(AnswerController.GetAnswerById), new { id = Question.AcceptedAnswerId });
        model.AnswersUrl = Url.Link(nameof(QuestionAnswersController.GetAnswersByQuestionId), new { id = Question.Id });
        return Ok(model);
    }




}
}
