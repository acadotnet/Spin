using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Spin.Data;
using Spin.Models;
using Spin.ViewModels.Albums;
using Spin.Services.Interfaces;
using System.IO;

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
            var album = new Album
            {
                ArtistId = id
            };

            return View(album);
        }

        [HttpPost]
        [Route("Add/{id}", Name = "AddAlbumPost")]
        public ActionResult Add(Album model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var album = _albumService.Add(model);

            return RedirectToRoute("ArtistDetails", new { id = model.ArtistId });
        }

        [Route("Edit/{id}", Name = "AlbumEdit")]
        public ActionResult Edit(int id)
        {
            var albumToEdit = _albumService.Get(id);

            return View(albumToEdit);
        }

        [HttpPost]
        [Route("Edit/{id}", Name = "AlbumEditPost")]
        public ActionResult Edit(Album model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var album = _albumService.Edit(model);

            return RedirectToRoute("AlbumDetails", new { id = album.Id });
        }

        [Route("Genre/{AlbumId}", Name = "AddGenre")]
        public ActionResult Genre(int AlbumId)
        {
            var model = new AddGenreViewModel
            {
                AlbumId = AlbumId
            };

            return View(model);
        }

        [HttpPost]
        [Route("Genre/{id}", Name = "AddGenrePost")]
        public ActionResult Genre(AddGenreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var genre = _albumService.AddGenre(model.AlbumId, model.Name);

            return RedirectToRoute("AlbumDetails", new { id = model.AlbumId });
        }

        [Route("GenreAlbums", Name = "GenreAlbumDetails")]
        public ActionResult GenreAlbums()
        {
            return View();
        }

        [Route("Details/{id}", Name = "AlbumDetails")]
        public ActionResult Details(int id)
        {
            var albums = _albumService.Get(id);

            return View(albums);
        }

        [HttpPost]
        public ActionResult ReadFile(Album model)
        {
            //var fileStream = new StreamReader();

            return View();
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