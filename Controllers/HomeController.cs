using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Data;
using Spin.Models;
using Spin.ViewModels;
using Spin.ViewModels.Home;

namespace Spin.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        protected readonly SpinContext _context;

        public HomeController()
        {
            _context = new SpinContext();
        }


        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
            {
                RecentArtists = _context.Artists.OrderByDescending(a => a.Id).Take(3).ToList(),
                RecentAlbums = _context.Albums.OrderByDescending(a => a.Id).Take(3).ToList()
            };


            return View(indexViewModel);
        }

        public ActionResult Albums()
        {
            ViewBag.Message = "Your favorite albums";

            return View();
        }
    }
}