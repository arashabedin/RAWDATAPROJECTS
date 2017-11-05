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
    [Route("api/marking")]
    public class MarkingController : CustomeController
    {
        private readonly IRepository _repository;
        private readonly IMapper _IMapper;

        public MarkingController(IRepository _Irepository, IMapper _IMapper)
        {
            this._repository = _Irepository;
            this._IMapper = _IMapper;

        }

        [HttpGet("{Pid}",Name =nameof(GetMarking) )]
        public IActionResult GetMarking(int Pid) {
            var markedPost = _repository.GetMarkingById(Pid);
            var newMarkingModel = new MarkingModel();
            newMarkingModel.PostUrl = _repository.GetPostById(markedPost.MarkedPostId).PostTypeId == 2 ?
                  Url.Link(nameof(AnswerController.GetAnswerById), new { Qid = _repository.GetPostById(markedPost.MarkedPostId).ParentId, Aid = markedPost.MarkedPostId }) :
                  Url.Link(nameof(QuestionController.GetQuestionById), new { Qid = markedPost.MarkedPostId });
            newMarkingModel.MarkingAnnotation = _repository.GetAnnotationById(Pid).Annotation;
            newMarkingModel.MarkedDate = markedPost.MarkingDate;
            return Ok(newMarkingModel);

        }

        // Get All Markings
        [HttpGet( Name = nameof(GetMarkings))]
        public IActionResult GetMarkings(int page = 0, int pageSize = 5)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountMarkings();
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetMarkings(page, pageSize)
                .Select(x => new MarkingModel
                {
                  PostUrl = _repository.GetPostById(x.MarkedPostId).PostTypeId == 2 ?
                  Url.Link(nameof(AnswerController.GetAnswerById), new { Qid = _repository.GetPostById(x.MarkedPostId).ParentId, Aid = x.MarkedPostId }) :
                  Url.Link(nameof(QuestionController.GetQuestionById), new { Qid = x.MarkedPostId }),
                  MarkingAnnotation = _repository.GetAnnotationById(x.MarkedPostId).Annotation,
                    MarkedDate = x.MarkingDate,
        });

            var result = new
            {
                Total = total,
                Pages = totalPages,
                Page = page,
                Prev = Link(nameof(GetMarkings), page, pageSize, -1, () => page > 0),
                Next = Link(nameof(GetMarkings), page, pageSize, 1, () => page < totalPages - 1),
                Url = Link(nameof(GetMarkings), page, pageSize),
                Data = data
            };

            return Ok(result);
        }


        [HttpPost("{Pid}",Name = nameof(AddMarking))]
        public IActionResult AddMarking(int Pid)
        {
            _repository.AddMarking(Pid);
            var markedPost = _repository.GetMarkingById(Pid);
            var newMarkingModel = new MarkingModel();
            // Checking whether the post is an answer or question to give it the correct link
            newMarkingModel.PostUrl = _repository.GetPostById(markedPost.MarkedPostId).PostTypeId == 2 ?
                     Url.Link(nameof(AnswerController.GetAnswerById), new { Qid = _repository.GetPostById(markedPost.MarkedPostId).ParentId, Aid = markedPost.MarkedPostId }) :
                     Url.Link(nameof(QuestionController.GetQuestionById), new { Qid = markedPost.MarkedPostId });
            newMarkingModel.MarkingAnnotation = markedPost.Annotations.Annotation;
            newMarkingModel.MarkedDate = markedPost.MarkingDate;
            return Created($"api/categories/{Pid}", newMarkingModel);

        }
        /*
                [HttpPost("{Pid}/{annotation}", Name = nameof(AddMarking))]
                public IActionResult AddMarkingWithAnnotation(int Pid, string annotation)
                {
                    _repository.AddMarkingWithAnnotation(Pid, annotation);
                    var markedPost = _repository.GetMarkingById(Pid);
                    var newMarkingModel = new MarkingModel();
                    // Checking whether the post is an answer or question to give it the correct link
                    newMarkingModel.PostUrl = _repository.GetPostById(markedPost.MarkedPostId).PostTypeId == 2 ?
                             Url.Link(nameof(AnswerController.GetAnswerById), new { Qid = _repository.GetPostById(markedPost.MarkedPostId).ParentId, Aid = markedPost.MarkedPostId }) :
                             Url.Link(nameof(QuestionController.GetQuestionById), new { Qid = markedPost.MarkedPostId });
                    newMarkingModel.MarkingAnnotation = markedPost.Annotations.Annotation;
                    newMarkingModel.MarkedDate = markedPost.MarkingDate;
                    return Created($"api/categories/{Pid}", newMarkingModel);

                }
                */

        [HttpDelete("{Pid}", Name = nameof(RemoveMarking))]
        public IActionResult RemoveMarking(int Pid)
        {
           
           var marking =  _repository.RemoveMarking(Pid);
            if (!marking)
            {
                return NotFound();
            }

            return Ok("The selected marking has been deleted");
       

        }

    }
}
