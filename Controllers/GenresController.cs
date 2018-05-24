using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Services.Interfaces;

namespace Spin.Controllers
{
    [RoutePrefix("Genres")]
    public class GenresController : Controller
    {
        protected readonly IAlbum _genreService;

        public GenresController(IAlbum genreService)
        {
            _genreService = genreService;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [Route("Albums/{genreId}", Name = "AllAlbumsByGenre")]
        public ActionResult Albums(int genreId)
        {
            var model = _genreService.GetAlbumsByGenreId(genreId);

            return View(model);
        }
    }
}