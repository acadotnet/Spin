using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spin.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Artist Name")]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}