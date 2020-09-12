
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Forum.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Your Question Here:")]
        public string Body { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }
        [Required]
        public string IdentityUserId { get; set; }

        public virtual Post Post { get; set; }

     
        public int? PostId { get; set; }


    }
}