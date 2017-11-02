using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataService.DataAccessLayer;
using DataService.DTO;
using System.Web.Http.Routing;
using WebService.Util;

namespace WebService.Models
{
    public static class ModelFactory
    {
        private static readonly IMapper _AnswerMapper;

        static ModelFactory()
        {

            var answerConfiguration = new MapperConfiguration(cfg => cfg.CreateMap<AnswerDTO, AnswerModel>());
            _AnswerMapper = answerConfiguration.CreateMapper();

        }


        public static AnswerModel Map(AnswerDTO answer, UrlHelper urlHelper)
        {
            if (answer == null) return null;

            var answerModel = _AnswerMapper.Map<AnswerModel>(answer);
            answerModel.Url = urlHelper.Link(Config.AnswersRoute, new { answer.Id });
            answerModel.UserUrl = urlHelper.Link(Config.UsersRoute, new { Id = answer.OwneruserId });
            answerModel.QuestionUrl = urlHelper.Link(Config.QuestionsRoute, new { Id = answer.ParentId });
            answerModel.CommentsUrl = urlHelper.Link(Config.AnswersCommentsRoute, new { answerId = answer.Id });

            return answerModel;
        }



    }
}
