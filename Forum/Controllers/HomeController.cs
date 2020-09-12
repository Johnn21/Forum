using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
           

            if (User.IsInRole("CanDeletePosts"))
            {
                var AllPosts = _context.Posts.Include(p => p.IdentityUser).ToList();

                return View("HomeAdmin", AllPosts);

            }
            else
            {
                var posts = _context.Posts.Include(p => p.IdentityUser).ToList();

                return View(posts);
            }
           


            //  var customers = _context.Customers.Include(c => c.MembershipType).ToList();


       
        }

        public ActionResult ShowPhones()
        {

            var phones = _context.Posts.Where(p => p.PostTypeId == 1).ToList();

            return View(phones);
        }

        public ActionResult ShowTablets()
        {

            var tablets = _context.Posts.Where(p => p.PostTypeId == 2).ToList();

            return View(tablets);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}