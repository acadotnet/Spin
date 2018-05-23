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

        public IEnumerable<Artist> GetAllArtists()
        {
            return _spinContext.Artists.Include(a => a.Albums.Select(b => b.AlbumGenres.Select(c => c.Genre))).ToList();
        }

        public Artist Get(int id)
        {
            return _spinContext.Artists.Include(a => a.Albums).FirstOrDefault(a => a.Id == id);
        }

        public Artist Edit(Artist model)
        {
            var edit = _spinContext.Artists.Include(a => a.Albums).FirstOrDefault(a => a.Id == model.Id);

            edit.Name = model.Name;
            edit.ArtistImageURL = model.ArtistImageURL;

            _spinContext.SaveChanges();

            return model;
        }

        public bool IsDuplicate(string name)
        {
            var genres = _spinContext.Genres.FirstOrDefault(g => g.Name == name);

            if (genres != null)
            {
                return true;
            }

            return false;
        }

        public Genre CreateGenre(string name)
        {
            var genre = new Genre
            {
                Name = name
            };

            _spinContext.Genres.Add(genre);
            _spinContext.SaveChanges();

            return genre;
        }

        public Artist Create(Artist model)
        {
            _spinContext.Artists.Add(model);
            _spinContext.SaveChanges();

            return model;
        }

        public void Delete(int id)
        {
            var artistToDelete = _spinContext.Artists.FirstOrDefault(a => a.Id == id);

            _spinContext.Artists.Remove(artistToDelete);
            _spinContext.SaveChanges();
        }
    }
}