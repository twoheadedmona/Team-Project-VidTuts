using GreenBears.VideoTuts.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenBears.VideoTuts.Admin.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && db.Admin.Any(x => x.Username == User.Identity.Name))
                return RedirectToAction("Index", "Admin");
            return View();
        }
        
    }
}