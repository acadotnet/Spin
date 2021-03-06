﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spin.Areas.Admin.Controllers
{
    //[RouteArea("Admin")]
    //[RoutePrefix("Artist")]
    //public class ArtistsController : Controller
    //{
    //    // GET: Admin/Artists
    //    protected readonly IArtist _artistService;
    //    protected readonly SpinContext _context;

    //    public ArtistsController(IArtist artistService)
    //    {
    //        _context = new SpinContext();
    //        _artistService = artistService;
    //    }

    //    [Route("", Name = "AllArtists")]
    //    public ActionResult Index()
    //    {
    //        var artist = _artistService.GetAllArtists();

    //        return View(artist);
    //    }

    //    [Route("Create", Name = "CreateArtist")]
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    [Route("Create", Name = "ArtistCreatePost")]
    //    public ActionResult Create(Artist model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model);
    //        }

    //        var artist = _artistService.Create(model);

    //        return RedirectToRoute("ArtistDetails", new { Id = artist.Id });
    //    }

    //    [Route("Edit/{id}", Name = "ArtistEdit")]
    //    public ActionResult Edit(int id)
    //    {
    //        var artistToEdit = _artistService.Get(id);

    //        return View(artistToEdit);
    //    }

    //    [HttpPost]
    //    [Route("Edit/{id}", Name = "ArtistEditPost")]
    //    public ActionResult Edit(Artist model)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return HttpNotFound();
    //        }

    //        _artistService.Edit(model);

    //        return RedirectToRoute("ArtistDetails", new { id = model.Id });
    //    }

    //    [HttpPost]
    //    [Route("AddSong/{id}", Name = "AddSongAjax")]
    //    public JsonResult AddSong(Songs model)
    //    {
    //        var songToAdd = new Songs
    //        {
    //            Id = model.Id,
    //            Name = model.Name,
    //            AlbumId = model.AlbumId,
    //            SongLength = model.SongLength
    //        };

    //        _context.Songs.Add(songToAdd);
    //        _context.SaveChanges();

    //        return Json(songToAdd);
    //    }

    //    [Route("Details/{id}", Name = "ArtistDetails")]
    //    public ActionResult Details(int id)
    //    {
    //        var artist = _artistService.Get(id);
    //        var genreList = new List<Genre>();
    //        //var genres = artist.Albums.Select(a => a.AlbumGenres.Select(b => b.Genre).Distinct()).Distinct().ToList();
    //        foreach (var album in artist.Albums)
    //        {
    //            foreach (var albumGenre in album.AlbumGenres)
    //            {
    //                if (genreList.Any(a => a.Name == albumGenre.Genre.Name))
    //                {
    //                    genreList.Add(albumGenre.Genre);
    //                }
    //            }
    //        }

    //        var model = new ArtistsDetailsViewModel
    //        {
    //            Artist = artist,
    //            Genres = genreList
    //        };

    //        return View(model);
    //    }

    //    [Route("Delete/{id}", Name = "ArtistDelete")]
    //    public ActionResult Delete(int id)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(id);
    //        }

    //        _artistService.Delete(id);

    //        return View();
    //    }
    //}
}