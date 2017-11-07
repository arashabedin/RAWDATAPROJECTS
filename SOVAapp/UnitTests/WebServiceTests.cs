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

namespace UnitTests
{
    public class WebServiceTest: Helpers
    {
        private const string UsersApi = "http://localhost:5001/api/user/1";
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




    }
}
