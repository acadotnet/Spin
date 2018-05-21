using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spin.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        [Required]
        [Display(Name="Album Name")]
        public string Name { get; set; }
        [Display(Name = "Album Image Url")]
        public string AlbumImageURL { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Songs> Songs { get; set; }
        public ICollection<AlbumGenre> AlbumGenres { get; set; }
    }
}