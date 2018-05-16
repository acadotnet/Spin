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

namespace Spin.Controllers
{
    [RoutePrefix("Albums")]
    public class AlbumsController : Controller
    {
        public SpinContext _context;

        public AlbumsController()
        {
            _context = new SpinContext();

        }

        [Route("", Name = "AllAlbums")]
        public ActionResult Index()
        {
            var albums = _context.Albums.Include(g => g.AlbumGenre.Select(n => n.Genre)).ToList();

            return View(albums);
        }

        [Route("Details/{id}", Name = "AlbumDetails")]
        public ActionResult Details(int id)
        {
            var albums = _context.Albums.Include(s => s.Songs).FirstOrDefault(a => a.Id == id);

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