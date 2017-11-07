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
        [HttpPost("{text}_{from}_{to}", Name = nameof(AddAnnotation))]
        public IActionResult AddAnnotation(int Pid, string text, int from, int to) {

          
               var addedAnnotation =  _repository.AddAnnotation(Pid, text, from, to);
                var annotationModel = new AnnotationModel();
                annotationModel.MarkingLink = Url.Link(nameof(MarkingController.GetMarking), new { Pid = addedAnnotation.MarkedPostId });
                annotationModel.AnnotationText = addedAnnotation.Annotation;
                annotationModel.From = addedAnnotation.From;
                annotationModel.To = addedAnnotation.To;
                annotationModel.EditAnnotation = Url.Link(nameof(AnnotationController.EditAnnotation), new { Pid = addedAnnotation.MarkedPostId, text = "Edited_Annotation" });
                annotationModel.RemoveAnnotation = Url.Link(nameof(AnnotationController.RemoveAnnotation), new { Pid = addedAnnotation.MarkedPostId });
                return Created($"api/marking/{Pid}/annotation", annotationModel);
        
        }


        [HttpDelete("{AnnotId}", Name = nameof(RemoveAnnotation))]
        public IActionResult RemoveAnnotation(int AnnotId)
        {

            if (_repository.GetAnnotationById(AnnotId).Annotation == "Empty")
            {
                return NotFound("There's no annotation to delete");
            }
            else
            {
                _repository.DeleteAnnotation(AnnotId);
                return Ok("Annotation has been deleted");
                
            }

        }

        [HttpPut("{AnnotId}/{text}", Name = nameof(EditAnnotation))]
        public IActionResult EditAnnotation(int AnnotId, string text)
        {

            if (_repository.GetAnnotationById(AnnotId).Annotation == "Empty")
            {
                return NotFound("There's no annotation to Edit");
            }
            else
            {
               var editedAnnotation = _repository.EditAnnotation(AnnotId, text);
                var annotationModel = new AnnotationModel();
                annotationModel.MarkingLink = Url.Link(nameof(MarkingController.GetMarking), new { Pid = editedAnnotation.MarkedPostId });
                annotationModel.AnnotationText = editedAnnotation.Annotation;
                annotationModel.EditAnnotation = Url.Link(nameof(AnnotationController.EditAnnotation), new { AnnotId = editedAnnotation.Annotationid, text = "Edited_Annotation" });
                annotationModel.RemoveAnnotation = Url.Link(nameof(AnnotationController.RemoveAnnotation), new { Pid = editedAnnotation.MarkedPostId });
                return Ok(annotationModel);

            }
        }




    }
}
