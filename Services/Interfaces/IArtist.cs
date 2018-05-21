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
        Artist Get(int id);
        Artist Create(EditViewModel model);
    }
}