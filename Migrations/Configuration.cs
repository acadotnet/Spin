namespace Spin.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Spin.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Spin.Data.SpinContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Spin.Data.SpinContext context)
        {
            var genre = new Genre
            {
                Id = 1,
                Name = "Rock N Roll"
            };

            var artist = new Artist
            {
                Id = 1,
                Name = "My Chemical Romance"
            };

            var album = new Album
            {
                Id = 1,
                Name = "Danger Days: True Lives of the Fabulous Killjoys",
                ArtistId = artist.Id
            };

            var albumGenres = new AlbumGenre
            {
                Id = 1,
                AlbumId = album.Id,
                GenreId = genre.Id
            };

            var songs = new Songs
            {
                Id = 1,
                Name = "NANANA",
                AlbumId = album.Id,
                SongLength = 4.00M
            };

            //context.Artists.AddOrUpdate(artist);
            //context.Albums.AddOrUpdate(album);
            //context.Genres.AddOrUpdate(genre);
            //context.AlbumGenres.AddOrUpdate(albumGenres);
            //context.Songs.AddOrUpdate(songs);
            //context.SaveChanges();
        }
    }
}
