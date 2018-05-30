using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spin.Models;

namespace Spin.ViewModels.Artists
{
    public class ArtistsDetailsViewModel
    {
        public Artist Artist { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Video> Videos { get; set; }
    }
}