using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Answer
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Your Answer Here:")]
        public string Body { get; set; }



        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }


    }
}