using Forum.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.ViewModels
{
    public class PostQuestionsModel
    {

        public Post Post { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public Question Question { get; set; }

        public Review Review { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public Answer Answer { get; set; }

        public PhoneData PhoneData { get; set; }

        public TabletData TabletData { get; set; }
    }
}