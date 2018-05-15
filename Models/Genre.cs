using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spin.Models
{
    public class Genre
    {
        public int Id { get; set; }
        //public int AlbumId { get; set; }
        [Required]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }
        public ICollection<AlbumGenre> AlbumGenres { get; set; }
    }
}