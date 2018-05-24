using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spin.Models;

namespace Spin.ViewModels.Home
{
    public class IndexViewModel
    {
        public List<Artist> RecentArtists { get; set; }
        public List<Album> RecentAlbums { get; set; }
        public List<Genre> Genres { get; set; }
    }
}