using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Data;
using Spin.Models;
using Spin.ViewModels;
using Spin.ViewModels.Home;
using Spin.Services.Interfaces;

namespace Spin.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        protected readonly SpinContext _context;

        public HomeController(SpinContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            var genreCount = _context.Genres.Count();

            var model = new IndexViewModel
            {
                RecentAlbums = _context.Albums.OrderByDescending(a => a.Id).Take(3).ToList(),
                RecentArtists = _context.Artists.OrderByDescending(a => a.Id).Take(3).ToList(),
                Videos = _context.Videos.OrderByDescending(a => a.Id).Take(3).ToList(),
                Genres = _context.Genres.OrderByDescending(a => a.Id).Take(genreCount).ToList()
            };

            return View(model);
        }

        public ActionResult Albums()
        {
            ViewBag.Message = "Your favorite albums";

            return View();
        }
    }
}