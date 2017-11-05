﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("api/searchhistory")]
    public class SearchHistoryController : CustomeController
    {


        private readonly IRepository _repository;
        private readonly IMapper _mapper;


        public SearchHistoryController(IRepository _repository, IMapper mapper)
        {
            this._repository = _repository;
            this._mapper = mapper;

        }

        [HttpGet(Name = nameof(GetSearchHistories))]
        public IActionResult GetSearchHistories(int page = 0, int pageSize = 5)
        {
            CheckPageSize(ref pageSize);

            var total = _repository.GetNumberOfSearches();
            var totalPages = GetTotalPages(pageSize, total);

            var data = _repository.GetSearchHistories(page, pageSize)
                .Select(x => new SearchHistoryModel
                {
                    SearchHistoryUrl = Url.Link(nameof(GetSearchHistoryById), new { Sid = x.Id }),
                    SearchText = x.SearchContent,
                    SearchDate = x.SearchDate

                });

            var result = new
            {
                Total = total,
                Pages = totalPages,
                Page = page,
                Prev = Link(nameof(GetSearchHistories), page, pageSize, -1, () => page > 0),
                Next = Link(nameof(GetSearchHistories), page, pageSize, 1, () => page < totalPages - 1),
                Url = Link(nameof(GetSearchHistories), page, pageSize),
                Data = data
            };

            return Ok(result);
        }
        [HttpGet("{Sid}",Name = nameof(GetSearchHistoryById))]
        public IActionResult GetSearchHistoryById(int Sid) {
            var s = _repository.GetSearchHistoryById(Sid);

            if(s != null)
            {
                var model = new SearchHistoryModel();
                model.SearchHistoryUrl = Url.Link(nameof(GetSearchHistoryById), new {Sid = s.Id });
                model.SearchText = s.SearchContent;
                model.SearchDate = s.SearchDate;
                return Ok(model);

            }
            return NotFound();

        }


    }
}
