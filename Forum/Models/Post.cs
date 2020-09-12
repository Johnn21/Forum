using Antlr.Runtime.Tree;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Post Name")]
        public string Name { get; set; }
       
        [Required]
        [Display(Name = "Post Description")]
        public string Body { get; set; }

        public DateTime DateAdded { get; set; }


        public virtual PostType PostType { get; set; }
        public int PostTypeId { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }
        [Required]
        public string IdentityUserId { get; set; }

    }
}