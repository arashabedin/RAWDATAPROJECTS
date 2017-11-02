using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class QuestionModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string UserUrl { get; set; }
        public string AcceptedAnswerUrl { get; set; }

        public string AnswersUrl { get; set; }

        public string CommentsUrl { get; set; }
    }
}
