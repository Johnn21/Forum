using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.ViewModels
{
    public class CreatePostModel
    {
        public Post Post { get; set; }
        public PhoneData PhoneData { get; set; }
        public TabletData TabletData { get; set; }
        public IEnumerable<PostType> PostTypes { get; set; }


    }
}