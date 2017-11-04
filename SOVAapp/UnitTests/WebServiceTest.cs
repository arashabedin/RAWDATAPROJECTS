using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using DataService.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    class WebServiceTest
    {

        private const string questionsApi = "http://localhost:5001/api/question";

        [Fact]
        public void GetQuestions_ValidId_ReturnsOk()
        {
            var mockDataAccess = new Mock<IRepository>();
            mockDataAccess.Setup(o => o.GetQuestionById(It.IsAny<int>())).Returns(new Question());

            var QuestionsControllers = new QuestionControllers(mockDataAccess.Object);

            var response = QuestionsControllers.GetQuestionById(1);

            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public void GetQuestionById_InvalidId_ReturnsNotFund()
        {
            var dataServviceMock = new Mock<IRepository>();

            var ctrl = new QuestionsControllers(dataServviceMock.Object);

            var response = ctrl.GetQuestionById(2);

            Assert.IsType<NotFoundResult>(response);
        }

    }
}
