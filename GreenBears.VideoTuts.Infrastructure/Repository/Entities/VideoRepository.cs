using GreenBears.VideoTuts.Core.Entities;
using GreenBears.VideoTuts.Infrastructure.Data;
using GreenBears.VideoTuts.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GreenBears.VideoTuts.Infrastructure.Repository.Entities
{
    public class VideoRepository : IVideoRepository
    {
        private DatabaseContext db = new DatabaseContext();

        public void Remove(Core.Entities.Video video)
        {
            var videoid = video.ID;
            var videotodelete = db.Videos.Where(x => x.ID == videoid).First();
            db.Videos.Remove(videotodelete);
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            db.Videos.Remove(db.Videos.Find(id));
            db.SaveChanges();
        }

        public void Create(Video newitem)
        {
            newitem.DateCreated = DateTime.Now;
            newitem.IsAproved = false;
            var uR = new UserRepository();
            var user = uR.GetCurrent();
            user.Videos.Add(newitem);
            uR.Edit(user);
            db.SaveChanges();
        }

        public void Edit(Video item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Core.Entities.Video Get(int id)
        {
            return db.Videos.Find(id);
        }

        public List<Core.Entities.Video> GetAll()
        {
            return db.Videos.ToList();
        }

        public void Aproove(int id)
        {
            var video = db.Videos.SingleOrDefault(x => x.ID == id);
            video.IsAproved = true;
            Edit(video);
        }



        public IEnumerable<Video> GetByTag(string tag)
        {
            List<Video> videos = new List<Video>();
            foreach (var video in db.Videos)
            {

                if (video.Tags.Contains(tag)) videos.Add(video);
            }
            return videos;
        }
        
        
        public void AddView(int id)
        {
            var video = Get(id);
            video.Views+=1;
            Edit(video);
        }
    }
}
