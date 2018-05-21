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

        public Album Add(Album album)
        {
            var artist = _spinContext.Artists.FirstOrDefault(a => a.Id == album.ArtistId);
            var newAlbum = new Album
            {
                Id = album.Id,
                Name = album.Name,
                Songs = album.Songs,
                ArtistId = album.ArtistId,
                AlbumImageURL = album.AlbumImageURL
            };
            _spinContext.Albums.Add(newAlbum);
            _spinContext.SaveChanges();

            return newAlbum;
        }

        public void Delete(int id, Album album)
        {
            var albumToDelete = _spinContext.Albums.FirstOrDefault(a => a.Id == id);
            _spinContext.Albums.Remove(albumToDelete);
            _spinContext.SaveChanges();
        }

        public Album Edit(int id, Album album)
        {
            var albumToEdit = _spinContext.Albums.FirstOrDefault(a => a.Id == id);
            var edit = new Album
            {
                Id = album.Id,
                Name = album.Name,
                Songs = album.Songs,
                ArtistId = album.ArtistId,
                AlbumImageURL = album.AlbumImageURL
            };
            return edit;
        }

        public Album Get(int id)
        {
            return _spinContext.Albums.Include(s => s.Songs).FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _spinContext.Albums.Include(a => a.AlbumGenres.Select(g => g.Genre)).ToList();
        }
    }
}