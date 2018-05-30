using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spin.Services.Interfaces;

namespace Spin.Controllers
{
    [RoutePrefix("Video")]
    public class VideoController : Controller
    {
        protected readonly IArtist _artistContext;
        
        public VideoController(IArtist artistContext)
        {
            artistContext = _artistContext;
        }

        [Route("", Name = "VideoIndex")]
        public ActionResult Index()
        {
            return View();
        }
    }
}