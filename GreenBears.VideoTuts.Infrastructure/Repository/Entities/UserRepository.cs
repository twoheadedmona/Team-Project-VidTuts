using GreenBears.VideoTuts.Core.Entities;
using GreenBears.VideoTuts.Infrastructure.Data;
using GreenBears.VideoTuts.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace GreenBears.VideoTuts.Infrastructure.Repository.Entities
{
    public class UserRepository:IUserRepository
    {
        private DatabaseContext db = new DatabaseContext();

        

        public void Remove(Core.Entities.User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            var user = Get(id);
            var vr = new VideoRepository();
            foreach (var video in user.Videos)
            {
                
                user.Videos.Remove(video);
                vr.Remove(video);
            }
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
        }

        public void Create(User newitem)
        {
            newitem.DateCreated=DateTime.Now;
            newitem.IsAproved = false;
            db.Users.Add(newitem);
            db.SaveChanges();
        }

        public void Edit(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Core.Entities.User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<Core.Entities.User> GetAll()
        {
            List<User> users = db.Users.ToList();
            return users;
        }

        public void Aproove(int id)
        {
            var user = db.Users.SingleOrDefault(x => x.ID == id);
            user.IsAproved = true;
            Edit(user);
        }


        public User GetByUsername(string username)
        {
            return db.Users.FirstOrDefault(x => x.Username == username);
        }

        public User GetByEmail(string email)
        {
            return db.Users.FirstOrDefault(x => x.Email == email);
        }

        public User GetCurrent()
        {
            var currUser = System.Web.HttpContext.Current.User.Identity.Name;
            return GetByUsername(currUser);
        }
    }
}
