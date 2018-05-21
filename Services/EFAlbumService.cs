using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Spin.Data;
using Spin.Models;
using Spin.Services.Interfaces;

namespace Spin.Services
{
    public class EFAlbumService : IAlbum
    {
        protected readonly SpinContext _spinContext;

        public EFAlbumService(SpinContext spinContext)
        {
            _spinContext = spinContext;
        }

        public Album AddAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public Album DeleteAlbum(int id, Album album)
        {
            throw new NotImplementedException();
        }

        public Album EditAlbum(int id, Album album)
        {
            throw new NotImplementedException();
        }

        public Album GetAlbum(int id)
        {
            return _spinContext.Albums.Include(s => s.Songs).FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _spinContext.Albums.Include(a => a.AlbumGenres.Select(g => g.Genre)).ToList();
        }
    }
}