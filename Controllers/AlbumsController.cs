using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
    }
}