using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GreenBears.VideoTuts.Core.Entities;
using GreenBears.VideoTuts.Infrastructure.Data;

namespace GreenBears.VideoTuts.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Videos");
            return View();
        }
    }

}