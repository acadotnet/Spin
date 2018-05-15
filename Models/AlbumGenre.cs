using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spin.Models
{
    public class AlbumGenre
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public Album Album { get; set; }
        public Genre Genre { get; set; }
    }
}