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
    [Route("api/marking/{Pid}/annotation")]
    public class AnnotationController : CustomeController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;


        public AnnotationController(IRepository _repository, IMapper mapper)
        {
            this._repository = _repository;
            this._mapper = mapper;
        }

        [HttpGet( Name = nameof(GetAnnotration))]
        public IActionResult GetAnnotration(int Pid)
        {
            var annot = _repository.GetAnnotationById(Pid);
            var annotationModel = new AnnotationModel();
            annotationModel.MarkingLink = Url.Link(nameof(MarkingController.GetMarking), new { Pid = annot.MarkedPostId });
            annotationModel.AnnotationText = annot.Annotation;
            annotationModel.EditAnnotation = Url.Link(nameof(AnnotationController.EditAnnotation), new { Pid = annot.MarkedPostId, text = "Edited_Annotation" });
            annotationModel.RemoveAnnotation = Url.Link(nameof(AnnotationController.RemoveAnnotation), new { Pid = annot.MarkedPostId });
            return Ok( annotationModel);


        }
        [HttpPost("{text}", Name = nameof(AddAnnotation))]
        public IActionResult AddAnnotation(int Pid, string text) {

            if (_repository.GetAnnotationById(Pid).Annotation == "Empty") {
               var addedAnnotation =  _repository.AddAnnotation(Pid, text);
                var annotationModel = new AnnotationModel();
                annotationModel.MarkingLink = Url.Link(nameof(MarkingController.GetMarking), new { Pid = addedAnnotation.MarkedPostId });
                annotationModel.AnnotationText = addedAnnotation.Annotation;
                annotationModel.EditAnnotation = Url.Link(nameof(AnnotationController.EditAnnotation), new { Pid = addedAnnotation.MarkedPostId, text = "Edited_Annotation" });
                annotationModel.RemoveAnnotation = Url.Link(nameof(AnnotationController.RemoveAnnotation), new { Pid = addedAnnotation.MarkedPostId });
                return Created($"api/marking/{Pid}/annotation", annotationModel);
            } else
            {
                return NotFound("Annotation is already set");
            }
        }


        [HttpDelete(Name = nameof(RemoveAnnotation))]
        public IActionResult RemoveAnnotation(int Pid)
        {

            if (_repository.GetAnnotationById(Pid).Annotation == "Empty")
            {
                return NotFound("There's no annotation to delete");
            }
            else
            {
                _repository.DeleteAnnotation(Pid);
                return Ok("Annotation has been deleted");
                
            }

        }

        [HttpPut("{text}", Name = nameof(EditAnnotation))]
        public IActionResult EditAnnotation(int Pid, string text)
        {

            if (_repository.GetAnnotationById(Pid).Annotation == "Empty")
            {
                return NotFound("There's no annotation to Edit");
            }
            else
            {
               var editedAnnotation = _repository.EditAnnotation(Pid, text);
                var annotationModel = new AnnotationModel();
                annotationModel.MarkingLink = Url.Link(nameof(MarkingController.GetMarking), new { Pid = editedAnnotation.MarkedPostId });
                annotationModel.AnnotationText = editedAnnotation.Annotation;
                annotationModel.EditAnnotation = Url.Link(nameof(AnnotationController.EditAnnotation), new { Pid = editedAnnotation.MarkedPostId, text = "Edited_Annotation" });
                annotationModel.RemoveAnnotation = Url.Link(nameof(AnnotationController.RemoveAnnotation), new { Pid = editedAnnotation.MarkedPostId });
                return Ok(annotationModel);

            }
        }




    }
}
