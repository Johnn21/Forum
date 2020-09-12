using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime DateAdded { get; set; }

     //   public virtual IdentityUser IdentityUser { get; set; }
        [Required]
        public string IdentityUserId { get; set; }
    }
}