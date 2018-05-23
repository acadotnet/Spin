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
        Artist Edit(Artist model);
        Artist Create(Artist model);
        void Delete(int id);
        Genre CreateGenre(string name);
        bool IsDuplicate(string name);
    }
}