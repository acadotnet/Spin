using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spin.Models
{
    public class Songs
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        [Display(Name = "Song Name")]
        public string Name { get; set; }
        public decimal SongLength { get; set; }
    }
}