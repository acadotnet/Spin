using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Spin.Data;
using Spin.Models;
using Spin.Services.Interfaces;
using Spin.ViewModels;

namespace Spin.Services
{
    public class EFArtistService : IArtist
    {
        protected readonly SpinContext _spinContext;

        public EFArtistService(SpinContext spinContext)
        {
            _spinContext = spinContext;
        }

        public Artist CreateArtist(EditViewModel model)
        {
            var album = new Album
            {
                Name = model.Album.Name,
                ArtistId = model.Album.Id,
                AlbumImageURL = model.Album.AlbumImageURL
            };

            var genre = new Genre
            {
                Name = model.Genre.Name
            };

            var artist = new Artist
            {
                Name = model.Artist.Name,
                ArtistImageURL = model.Artist.ArtistImageURL
            };

            _spinContext.Artists.Add(artist);
            _spinContext.Albums.Add(album);
            _spinContext.Genres.Add(genre);
            _spinContext.SaveChanges();

            return artist;
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _spinContext.Artists.Include(a => a.Albums.Select(b => b.AlbumGenre.Select(c => c.Genre))).ToList();
        }

        public Artist GetArtist(int id)
        {
            return _spinContext.Artists.FirstOrDefault(a => a.Id == id);
        }
    }
}