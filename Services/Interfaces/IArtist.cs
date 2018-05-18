using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spin.Models;
using Spin.ViewModels;

namespace Spin.Services.Interfaces
{
    public interface IArtist
    {
        IEnumerable<Artist> GetAllArtists();
        Artist GetArtist(int id);
        Artist CreateArtist(EditViewModel model);
    }
}