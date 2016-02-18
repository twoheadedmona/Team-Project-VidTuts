using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GreenBears.VideoTuts.Core.Entities;
using GreenBears.VideoTuts.Infrastructure.Repository.Entities;
using GreenBears.VideoTuts.Infrastructure.Repository.Interfaces;

namespace GreenBears.VideoTuts.Web.Controllers
{
    public class VideosController : Controller
    {

        IVideoRepository videoRepository = new VideoRepository();
        // GET: Videos
        [Authorize]
        public ActionResult Index()
        {
            var list = videoRepository.GetAll().Where(x => x.IsAproved);
            return View(list);
        }

        // GET: Videos/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            videoRepository.AddView(id);
            Video video = videoRepository.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        [Authorize]
        public ActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult Create(string title, string description, string url, string tags)
        {
            if (ModelState.IsValid)
            {
                var video = new Video() { Title = title, Description = description, Url = url, Tags = tags };
                videoRepository.Create(video);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Search(string query, string criteria)
        {
            string[] checkboxgroup;
            if (criteria != null)
            {
                checkboxgroup = criteria.Split(',');
            }
            else
            {
                checkboxgroup = new string[3] { "1", "2", "3" };
            }
            List<Video> res = new List<Video>();

            if (checkboxgroup.Contains("1"))
            {
                UserRepository ur = new UserRepository();
                var user = ur.GetAll().Where(x => x.Username.Contains(query));
                foreach (var us in user)
                {
                    res.AddRange(us.Videos);
                }
            }
            if (checkboxgroup.Contains("2"))
            {
                res.AddRange(videoRepository.GetAll().Where(video => video.Title.Contains(query)));
            }
            if (checkboxgroup.Contains("3"))
            {
                res.AddRange(videoRepository.GetAll().Where(video => video.Tags.Contains(query)));
            }
            var list = res.Where(x => x.IsAproved).OrderByDescending(x => x.Views).ToList();
            return View("Index", list);
        }

    }
}
