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
        Album Add(Album album);
        Album Edit(int id, Album album);
        void Delete(int id, Album album);
    }
}