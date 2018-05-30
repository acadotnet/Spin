using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Spin.Models;

namespace Spin.Data
{
    public class SpinContext : DbContext
    {
        public SpinContext()
            : base("Name=SpinContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SpinContext, Migrations.Configuration>());
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}