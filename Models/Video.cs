using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spin.Models
{
    public class Video
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        [Display(Name = "Video Title")]
        public string Name { get; set; }
        [Display(Name = "Video URL")]
        public string Url { get; set; }
        public Artist Artist { get; set; }
    }
}