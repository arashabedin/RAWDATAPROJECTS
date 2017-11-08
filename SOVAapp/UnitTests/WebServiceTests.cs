using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using System.Diagnostics;
using DataService.DataAccessLayer;
using Moq;
using AutoMapper;
using WebService.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class WebServiceTest: Helpers
    {
      
        [Fact]
        public void ApiGetAllQuestions_ReturnListOfQuestions_withValues()
        {
            string QuestionsApi = "http://localhost:5001/api/question";
            var (data, statusCode) = GetObject(QuestionsApi);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(2237, data["total"]);
            Assert.Equal("Chris Jester-Young", data["data"][0]["userName"]);
            Assert.Equal(4, data["data"][1]["tags"].Count());

        }

        [Fact]
        public void ApiQuestions_GetWithId_ContainsURL()
        {       
            string QuestionsApi = "http://localhost:5001/api/question/19";

            var(data, statusCode) = GetObject(QuestionsApi);

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal("http://localhost:5001/api/question/19", data["url"]);
            Assert.Equal(12, data.Count);

        }

        [Fact]
        public void ApiUser_InvalidId_NotFound()
        {
            string UserApi = "http://localhost:5001/api/user";
            var (user, statusCode) = GetObject($"{UserApi}/0");
            Assert.Equal(HttpStatusCode.NotFound, statusCode);

        }

        [Fact]
        public void ApiCustomeField_AddNewCustomeField()
        {

            var client = new HttpClient();
            var response = client.PostAsync("http://localhost:5001/api/customization/5_sql,wordpress,jumla", null).Result;
            Assert.Equal(true , response.IsSuccessStatusCode);
            string CustomeApi = "http://localhost:5001/api/customization";
            var (data, statusCode) = GetObject(CustomeApi);
            Assert.Equal("jumla", data["favortieTags"][2]);
            //Checking that the postlimit of Recommended questions according to our favorite tags equals 5
            string HomeApi = "http://localhost:5001/api";
            var (data2, statusCode2) = GetObject(HomeApi);
            Assert.Equal(5, data2["recommendedQuestions"].Count());

        }


 [Fact]
        public void ApiGetAllMarking_ReturnListOfMarking_withValues()
        {
            string MarkingApi = "http://localhost:5001/api/Marking";
            var (data, statusCode) = GetObject(MarkingApi);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(6, data["total"]);
            Assert.Equal("http://localhost:5001/api/marking/86513", data["data"][0]["markingUrl"]);

        }

        public void ApiGetsearchHistory_ReturnListOfSearchHistory_withValues()
        {
            string SearchHistoryApi = "http://localhost:5001/api/searchhistory";
            var (data, statusCode) = GetObject(SearchHistoryApi);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(337, data["total"]);
            Assert.Equal("angular", data["data"][1]["searchText"]);

        }


        public void ApiGetUser_ReturnListOfUsers()
        {
            string UserApi = "http://localhost:5001/api/user";
            var (data, statusCode) = GetObject(UserApi);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(11392, data["total"]);
            Assert.Equal("Jeff Atwood", data["data"][0]["displayName"]);
            String UserId = "http://localhost:5001/api/user/3";
            var (data2, StatusCode) = GetObject(UserId);
            Assert.Equal("New York, NY", data2["data"][1]["location"]);


        }

        [Fact]
        public void GetQuestionById_InvalidId_ReturnsNotFund()
        {
            var dataServviceMock = new Mock<IRepository>();
            var imapperMock = new Mock<IMapper>();

            var ctrl = new QuestionController(dataServviceMock.Object, imapperMock.Object);

            var response = ctrl.GetQuestionById(1);
            Assert.IsType<NotFoundResult>(response);
        }


    }
}
