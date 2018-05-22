using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Spin.Data;
using Spin.Models;
using Spin.ViewModels;
using Spin.Services.Interfaces;

namespace Spin.Controllers
{
    [RoutePrefix("Albums")]
    public class AlbumsController : Controller
    {
        private readonly SpinContext _context;
        private readonly IAlbum _albumService;

        public AlbumsController(IAlbum albumService)
        {
            _albumService = albumService;
        }

        [Route("", Name = "AllAlbums")]
        public ActionResult Index()
        {
            var albums = _albumService.GetAllAlbums();

            return View(albums);
        }

        [Route("Add/{id}", Name = "AddAlbum")]
        public ActionResult Add(int id)
        {
            var artist = _context.Artists.Include(n => n.Albums).FirstOrDefault(a => a.Id == id);

            return View(artist);
        }

        [HttpPost]
        [Route("Add/{id}", Name = "AddAlbumPost")]
        public ActionResult Add(EditViewModel model)
        {
            var album = new Album
            {
                Name = model.Album.Name,
                AlbumImageURL = model.Album.AlbumImageURL,
                ArtistId = model.Artist.Id
            };

            _context.Albums.Add(album);
            _context.SaveChanges();

            return RedirectToRoute("ArtistDetails", new { id = model.Artist.Id });
        }

        [Route("Details/{id}", Name = "AlbumDetails")]
        public ActionResult Details(int id)
        {
            var albums = _albumService.Get(id);

            return View(albums);
        }
        
        [HttpPost]
        [Route("Delete/{id}", Name = "DeleteSongAjax")]
        public ActionResult Delete(int id)
        {
            var songToDelete = _context.Songs.FirstOrDefault(s => s.Id == id);
            if (songToDelete != null)
            {
                _context.Songs.Remove(songToDelete);
                _context.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}