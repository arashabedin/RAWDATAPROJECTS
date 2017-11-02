using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.DataAccessLayer;
using DataService.DTO;
using System.Web.Http.Routing;
using WebService.Util;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/answers")]
    public class AnswerController : Controller
    { 
  private readonly IRepository _repository;

    public AnswerController(IRepository _repository)
    {
        this._repository = _repository;
    }

        [HttpGet(Name = nameof(GetAnswers))]
        public IActionResult GetAnswers(int page = 0, int pageSize = 2)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.CountAnswers();
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetAnswers(page, pageSize)
                .Select(x => new AnswerModel
                {
                    Url = Url.Link(nameof(GetAnswers), new { id = x.Id }),
                    Id = x.Id,
                    CreationDate = x.CreationDate,
                    Score = x.Score,
                    Body = x.Body,
                    UserUrl = Url.Link("Users", new { id = x.OwnerUserId }),
                    CommentsUrl = Url.Link("Comments", new { PostId = x.Comments }),
                });

            var result = new
            {
                Total = total,
                Pages = totalPages,
                Page = page,
                Prev = Link(nameof(GetAnswers), page, pageSize, -1, () => page > 0),
                Next = Link(nameof(GetAnswers), page, pageSize, 1, () => page < totalPages - 1),
                Url = Link(nameof(GetAnswers), page, pageSize),
                Data = data
            };

            return Ok(result);
        }

        // Helpers 

        private string Link(string route, int page, int pageSize, int pageInc = 0, Func<bool> f = null)
        {
            if (f == null) return Url.Link(route, new { page, pageSize });

            return f()
                ? Url.Link(route, new { page = page + pageInc, pageSize })
                : null;
        }

        private static int GetTotalPages(int pageSize, int total)
        {
            return (int)Math.Ceiling(total / (double)pageSize);
        }

        private static void CheckPageSize(ref int pageSize)
        {
            pageSize = pageSize > 50 ? 50 : pageSize;
        }

    }
}
