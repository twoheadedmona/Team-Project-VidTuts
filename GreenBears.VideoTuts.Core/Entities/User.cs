using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenBears.VideoTuts.Core.Entities
{
    public class User:BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Image { get; set; }
        public virtual List<Video> Videos { get; set; }

        public void AddVideo(Video video)
        {
            
            Videos.Add(video);
        }

        public void RemoveVideo(Video video)
        {
            Videos.Remove(video);
        }
    }
}
