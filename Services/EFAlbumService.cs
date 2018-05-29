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
            _spinContext.Albums.Add(album);
            _spinContext.SaveChanges();

            return album;
        }

        public Genre AddGenre(int id, string name)
        {
            var existingGenre = _spinContext.Genres.FirstOrDefault(a => a.Name == name);

            if (existingGenre == null)
            {
                existingGenre = new Genre
                {
                    Name = name
                };
                _spinContext.Genres.Add(existingGenre);
            }

            var album = _spinContext.Albums.Include(b => b.AlbumGenres).FirstOrDefault(a => a.Id == id);
            
            if (!album.AlbumGenres.Any(a => a.GenreId == existingGenre.Id))
            {
                var model = new AlbumGenre
                {
                    AlbumId = album.Id,
                    GenreId = existingGenre.Id
                };

                album.AlbumGenres.Add(model);
            }

            _spinContext.SaveChanges();

            return existingGenre;
        }

        public void Delete(int id, Album album)
        {
            var albumToDelete = _spinContext.Albums.FirstOrDefault(a => a.Id == id);
            _spinContext.Albums.Remove(albumToDelete);
            _spinContext.SaveChanges();
        }

        public Album Edit(Album model)
        {
            var albumToEdit = _spinContext.Albums.FirstOrDefault(a => a.Id == model.Id);
            albumToEdit.Name = model.Name;
            albumToEdit.AlbumImageURL = model.AlbumImageURL;

            _spinContext.SaveChanges();

            return albumToEdit;
        }

        public Album Get(int id)
        {
            return _spinContext.Albums.Include(s => s.Songs).FirstOrDefault(a => a.Id == id);
        }
        
        public IEnumerable<Album> GetAlbumsByGenreId(int genreId)
        {
            return _spinContext.AlbumGenres
                .Include(a => a.Album)
                .Include(g => g.Genre)
                .Where(z => z.GenreId == genreId)
                .Select(a => a.Album)
                .Include(a => a.AlbumGenres.Select(g => g.Genre))
                .ToList();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _spinContext.Albums.Include(a => a.AlbumGenres.Select(g => g.Genre)).ToList();
        }
    }
}