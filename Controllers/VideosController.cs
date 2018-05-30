using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Models;
using Spin.Services.Interfaces;

namespace Spin.Controllers
{
    [RoutePrefix("Videos")]
    public class VideosController : Controller
    {
        protected readonly IVideo _videoService;
        
        public VideosController(IVideo videoService)
        {
            videoService = _videoService;
        }

        [Route("", Name = "AllVideos")]
        public ActionResult Index()
        {
            var artist = _videoService.GetAllVideos();

            return View(artist);
        }

        [Route("Add/{id}", Name = "AddVideo")]
        public ActionResult Add(int id)
        {
            var video = new Video
            {
                ArtistId = id
            };

            return View(video);
        }

        [HttpPost]
        [Route("Add/{id}", Name = "AddVideoPost")]
        public ActionResult Add(Video model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var video = _videoService.Add(model);

            return RedirectToRoute("ArtistDetails", new { id = model.ArtistId });
        }
    }
}