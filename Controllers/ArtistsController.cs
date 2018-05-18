using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Data;
using Spin.Models;
using Spin.Services;
using Spin.Services.Interfaces;
using Spin.ViewModels;

namespace Spin.Controllers
{
    [RoutePrefix("Artists")]
    public class ArtistsController : Controller
    {
        protected readonly IArtist _artistService;
        protected readonly SpinContext _context;

        public ArtistsController(IArtist artistService)
        {
            _context = new SpinContext();
            _artistService = artistService;
        }
        
        [Route("", Name = "AllArtists")]
        public ActionResult Index()
        {
            var artist =_artistService.GetAllArtists();

            return View(artist);
        }

        [Route("Create", Name = "CreateArtist")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create", Name = "ArtistCreatePost")]
        public ActionResult Create(EditViewModel model)
        {
            var artist = _artistService.CreateArtist(model);

            return RedirectToRoute("ArtistDetails", new { Id = artist.Id });
        }

        [Route("Edit/{id}", Name = "ArtistEdit")]
        public ActionResult Edit(int id)
        {
            var artistToEdit = _context.Artists.FirstOrDefault(a => a.Id == id);

            return View(artistToEdit);
        }

        [HttpPost]
        [Route("Edit/{id}", Name = "ArtistEditPost")]
        public ActionResult Edit(Artist model)
        {
            var artist = _context.Artists.FirstOrDefault(c => c.Id == model.Id);
            if (artist == null)
            {
                return HttpNotFound();
            }

            artist.Name = model.Name;
            artist.ArtistImageURL = model.ArtistImageURL;

            _context.SaveChanges();

            return RedirectToRoute("ArtistDetails");
        }

        [HttpPost]
        [Route("AddSong/{id}", Name = "AddSongAjax")]
        public JsonResult AddSong(Songs model)
        {
            var songToAdd = new Songs
            {
                Id = model.Id,
                Name = model.Name,
                AlbumId = model.AlbumId,
                SongLength = model.SongLength
            };
            
            _context.Songs.Add(songToAdd);
            _context.SaveChanges();

            return Json(songToAdd);
        }

        [Route("Details/{id}", Name = "ArtistDetails")]
        public ActionResult Details(int id)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);
            var albums = _context.Albums.Where(a => a.ArtistId == id).ToList();

            return View(artist);
        }

        [Route("Delete/{id}", Name = "ArtistDelete")]
        public ActionResult Delete(int id)
        {
            var artistToDelete = _context.Artists.FirstOrDefault(a => a.Id == id);

            _context.Artists.Remove(artistToDelete);
            _context.SaveChanges();

            return View();
        }
    }
}