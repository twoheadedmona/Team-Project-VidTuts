using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using GreenBears.VideoTuts.Core.Entities;
using GreenBears.VideoTuts.Infrastructure.Data;
using GreenBears.VideoTuts.Infrastructure.Repository.Entities;
using GreenBears.VideoTuts.Infrastructure.Repository.Interfaces;

namespace GreenBears.VideoTuts.Web.Controllers
{
    public class UsersController : Controller
    {
        IUserRepository userRepository=new UserRepository();
   

        [HttpPost]
        public ActionResult Register(string username, string password, string email)
        {
            User user = new User();
            user.Username = username;
            user.Password = password;
            user.Email = email;
            user.DateCreated=DateTime.Now;
            user.Image = "no image";
            userRepository.Create(user);

            return RedirectToAction("LogIn",new { username = username, password = password});

        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            var af = new AuthentificationFactory();
            var res = af.LogIn(username, password);
            if (res == AuthStatus.Done)
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index", "Videos");
            }
            return RedirectToAction("LogIn");
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        
    }
}
