using Forum.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Forum.ViewModels;
using System.Data.Entity.Migrations;
using System.Collections.Specialized;

namespace Forum.Controllers
{
    public class PostsController : Controller
    {

        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.AutoDetectChangesEnabled = false;
            _context.Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Posts
        public ActionResult Index()
        {

            Post post = new Post();
            PhoneData phoneData = new PhoneData();
            TabletData tabletData = new TabletData();

            var viewModel = new CreatePostModel
            {
                Post = post,
                PhoneData = phoneData,
                TabletData = tabletData,
                PostTypes = _context.PostTypes.ToList()
            };



            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Post post, PhoneData phoneData, TabletData tabletData,string decision)
        {
        //    var postDb = _context.Posts.Include(p => p.PostType).Single(p => p.Id == post.Id);

            if (post.Id == 0)
            {

                string strCurrentUserId = User.Identity.GetUserId();
                post.IdentityUserId = strCurrentUserId;
                post.DateAdded = DateTime.Now;


                if(decision == "addPhone")
                {
                    phoneData.PostId = post.Id;

                    _context.Posts.Add(post);
                    _context.PhoneDatas.Add(phoneData);

                }else if(decision == "addTablet")
                {
                    tabletData.PostId = post.Id;

                    _context.Posts.Add(post);
                    _context.TabletDatas.Add(tabletData);
                }

                

            }
            else
            {

                var postDb = _context.Posts.SingleOrDefault(p => p.Id == post.Id);
 
                postDb.Name = post.Name;
                postDb.Body = post.Body;

                _context.Entry(postDb).State = EntityState.Modified;


            }

            _context.SaveChanges();






            return RedirectToAction("Index", "Home");
        }

       
        public ActionResult Details(int id)
        {

            var post = _context.Posts.Include(c => c.IdentityUser).SingleOrDefault(p => p.Id == id);

            string strCurrentUserId = User.Identity.GetUserId();


            ViewBag.CurrentUserName = strCurrentUserId;


            var questionAsked = _context.Questions.Where(q => q.IdentityUserId == strCurrentUserId).Where(q => q.PostId == id).ToList();

            if (post == null)
                return HttpNotFound();

            Question question = new Question();
            Review review = new Review();
            Answer answer = new Answer();


            var viewModel = new PostQuestionsModel
            {
                Post = post,
                Questions = _context.Questions.Where(q => q.PostId == id).ToList(),
                Question = question,
                Review = review,
                Reviews = _context.Reviews.Where(r => r.PostId == id).ToList(),
                Answers = _context.Answers.ToList(),
                Answer = answer,
                PhoneData = _context.PhoneDatas.SingleOrDefault(p => p.PostId == id),
                TabletData = _context.TabletDatas.SingleOrDefault(t => t.PostId == id)

            };


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GetQuestion(Question question, int reportName)
        {
            string strCurrentUserId = User.Identity.GetUserId();
            question.IdentityUserId = strCurrentUserId;
            question.PostId = reportName;

            _context.Questions.Add(question);

         
            _context.SaveChanges();


            return RedirectToAction("Details", new { id = question.PostId });

        }

        public ActionResult UserPosts()
        {

            string strCurrentUserId = User.Identity.GetUserId();

            var post = _context.Posts.Where(p => p.IdentityUserId == strCurrentUserId).ToList();


            return View(post);
        }

        public ActionResult Edit(int id)
        {

            var post = _context.Posts.SingleOrDefault(p => p.Id == id);

            if(post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        [HttpPost]

        public ActionResult GetReview(Review review, int currentPostId)
        {

            string strCurrentUserId = User.Identity.GetUserId();
            review.IdentityUserId = strCurrentUserId;
            review.PostId = currentPostId;

            _context.Reviews.Add(review);

            _context.SaveChanges();


            return RedirectToAction("Details", new { id = review.PostId });
        }

        [HttpPost]

        public ActionResult GetAnswer(Answer answer, int questionId, int currentPostId)
        {
            answer.QuestionId = questionId;

            _context.Answers.Add(answer);

            _context.SaveChanges();

            return RedirectToAction("Details", new { id = currentPostId });
        }

        public ActionResult SearchPost(string search)
        {
            string test = search;

            return View();
        }

    }
}