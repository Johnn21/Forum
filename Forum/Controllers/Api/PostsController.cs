using AutoMapper;
using Forum.Dtos;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Forum.Controllers.Api
{
    public class PostsController : ApiController
    {
        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.ProxyCreationEnabled = false;

        }

        public IHttpActionResult GetPosts()
        {


            var postDto = _context.Posts.ToList().Select(Mapper.Map<Post, PostDto>);

            return Ok(postDto);
        }

        public IHttpActionResult GetPost(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);

            if(post == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Post, PostDto>(post));
        }

        [HttpPost]
        public IHttpActionResult CreatePost(PostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var post = Mapper.Map<PostDto, Post>(postDto);
            _context.Posts.Add(post);
            _context.SaveChanges();

            postDto.Id = post.Id;

            return Created(new Uri(Request.RequestUri + "/" + post.Id), postDto);
        }

      /*  [HttpPut]
        public IHttpActionResult UpdatePost (int id, PostDto postDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var postDb = _context.Posts.SingleOrDefault(p => p.Id == id);

            if(postDb == null)
            {
                NotFound();
            }

            Mapper.Map(postDto, postDb);

            _context.SaveChanges();

            return Ok();

        }*/

         [HttpPut]
         public void UpdatePost (int id, Post post)
        {
            var postDb = _context.Posts.SingleOrDefault(p => p.Id == id);

            postDb.Id = post.Id;
            postDb.IdentityUserId = post.IdentityUserId;
            postDb.Name = post.Name;
            postDb.Body = post.Body;
            postDb.DateAdded = post.DateAdded;

            _context.SaveChanges();
        }

        [HttpDelete]
        public IHttpActionResult DeletePost(int id)
        {
            var postDb = _context.Posts.SingleOrDefault(p => p.Id == id);
            var questionDb = _context.Questions.Where(q => q.PostId == id).ToList();

            if (postDb == null)
            {
                NotFound();
            }

            _context.Posts.Remove(postDb);
            _context.Questions.RemoveRange(questionDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
