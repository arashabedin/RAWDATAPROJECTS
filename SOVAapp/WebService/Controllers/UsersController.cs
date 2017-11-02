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
    [Route("api/users")]
    public class UsersController : CustomeController
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UsersController(IRepository _repository, IMapper mapper)
        {
            this._repository = _repository;
            this._mapper = mapper;
        }

        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers(int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountAnswers();
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetUsers(page, pageSize)
                .Select(x => new UserInfoModel
                {
                    Url = Url.Link(nameof(GetUsers), new { id = x.Id }),
                    DisplayName = x.DisplayName,
                    CreateDate = x.CreationDate,
                    Location = x.Location,
                    Age = x.Age,
                 //   QuestionsUrl = null
                    AnswersUrl = Url.Link(nameof(UserAnswersController.GetAnswersByUserId), new { id = x.Id }),
                    //  CommentsUrl = Url.Link(nameof(UserController.GetUserByUserId), new { id = x.OwnerUserId }),
                });

            var result = new
            {
                Total = total,
                Pages = totalPages,
                Page = page,
                Prev = Link(nameof(GetUsers), page, pageSize, -1, () => page > 0),
                Next = Link(nameof(GetUsers), page, pageSize, 1, () => page < totalPages - 1),
                Url = Link(nameof(GetUsers), page, pageSize),
                Data = data
            };

            return Ok(result);
        }

        

    }
}
