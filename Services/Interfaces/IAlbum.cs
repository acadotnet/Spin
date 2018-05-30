using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spin.Models;

namespace Spin.Services.Interfaces
{
    public interface IAlbum
    {
        IEnumerable<Album> GetAllAlbums();
        Album Get(int id);
        Album Add(Album model);
        Genre AddGenre(int id, string name);
        IEnumerable<Album> GetAlbumsByGenreId(int genreId);
        Album Edit(Album model);
        void Delete(int id, Album album);
    }
}