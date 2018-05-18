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
        Album GetAlbum(int id);
        Album AddAlbum(Album album);
        Album EditAlbum(int id, Album album);
        Album DeleteAlbum(int id, Album album);
    }
}