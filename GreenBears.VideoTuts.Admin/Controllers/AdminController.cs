using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GreenBears.VideoTuts.Core.Entities;
using GreenBears.VideoTuts.Infrastructure.Data;
using GreenBears.VideoTuts.Infrastructure.Repository.Entities;
using GreenBears.VideoTuts.Infrastructure.Repository.Interfaces;

namespace GreenBears.VideoTuts.Admin.Controllers
{
    public class AdminController : Controller
    {
        IUserRepository userRepository=new UserRepository();
        IVideoRepository videoRepository=new VideoRepository();
        DatabaseContext db=new DatabaseContext();
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            if (db.Admin.Count() == 0)
            {
                db.Admin.Add(new Core.Entities.Admin() {Password = "admin", Username = "admin"});
            }
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            var admin = db.Admin.Single(x => x.Username == username && x.Password == password);
            if (admin == null)
            {
                return RedirectToAction("LogIn");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index");
            }
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult ListVideosUnnaproved()
        {
            List<Video> unnaproovedVideos = db.Videos.Where(x => x.IsAproved==false).ToList();
            return View(unnaproovedVideos);
        }
        [Authorize]
        public ActionResult ListVideos()
        {
            List<Video> allvideos = db.Videos.ToList();
            return View(allvideos);
        }
        [Authorize]
        public ActionResult ListUsersUnnaproved()
        {
            List<User> unnaprovedUsers = db.Users.Where(x => !x.IsAproved).ToList();
            return View(unnaprovedUsers);

        }
        [Authorize]
        public ActionResult ListUsers()
        {
            List<User> allUsers = db.Users.ToList();
            return View(allUsers);
        }
        [Authorize]
        public ActionResult AprooveVideos(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Videos.SingleOrDefault(x=>x.ID==id)==null)
            {
                return HttpNotFound();
            }
            videoRepository.Aproove(id);

            return RedirectToAction("ListVideos");
        }
        [Authorize]
        public ActionResult AprooveUsers(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (db.Users.SingleOrDefault(x => x.ID == id) == null)
            {
                return HttpNotFound();
            }
            userRepository.Aproove(id);

            return RedirectToAction("ListUsers");
        }
        [Authorize]
        public ActionResult DeleteUsers(int id)
        {
            userRepository.Remove(id);
            return RedirectToAction("ListUsers");
        }
        [Authorize]
        public ActionResult DeleteVideos(int id)
        {
            videoRepository.Remove(id);
            return RedirectToAction("ListVideos");
        }
        [Authorize]
        public ActionResult EditVideos(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = videoRepository.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }
        [Authorize]
        public ActionResult EditUsers(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = userRepository.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



    }
}