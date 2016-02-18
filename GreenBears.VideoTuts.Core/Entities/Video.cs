using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenBears.VideoTuts.Core.Entities
{
    public class Video:BaseEntity
    {
        [Required]
        public string Title { get; set; }        
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
        public int Views { get; set; }
        [NotMapped]
        public string EmbedHtml
        {//the EmbedHtml prop doesnt go into database
            get
            {
               // return "<iframe id='ytplayer' type='text/html' width='640' height='390'  src='https://www.youtube.com/embed/BKiUKSbXaiQ'  frameborder='0'/>";
                if (Url == null) return "";
                //https://www.youtube.com/watch?v=BKiUKSbXaiQ the front end should check if the video link is format https://www.youtube.com/watch?v=VIDEOID
                var videoID = Url.Split('=');
                var embedLink = "https://www.youtube.com/embed/" + videoID[1];
                return String.Format("<iframe id='ytplayer' type='text/html' width='560' height='315'  src='{0}'  frameborder='0'/>", embedLink);
            }
        }
        [NotMapped]
        public string GetTumbnail {
            get
            {
                // return http://i1.ytimg.com/vi/1sFMxYaNvhw/0.jpg
                if (Url == null) return "";
                var videoID = Url.Split('=');
                return String.Format("http://i1.ytimg.com/vi/{0}/0.jpg", videoID[1]);
            }
        }

        public string Tags { get; set; }
    }
}
