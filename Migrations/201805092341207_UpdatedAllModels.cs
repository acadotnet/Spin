namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAllModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropIndex("dbo.Genres", new[] { "Album_Id" });
            RenameColumn(table: "dbo.Albums", name: "Artist_Id", newName: "ArtistId");
            CreateTable(
                "dbo.AlbumGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AlbumId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        Name = c.String(),
                        SongLength = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
            AlterColumn("dbo.Albums", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "ArtistId");
            AddForeignKey("dbo.Albums", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
            DropColumn("dbo.Albums", "GenreId");
            DropColumn("dbo.Genres", "Album_Id");
            DropColumn("dbo.Artists", "AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "AlbumId", c => c.Int(nullable: false));
            AddColumn("dbo.Genres", "Album_Id", c => c.Int());
            AddColumn("dbo.Albums", "GenreId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.AlbumGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.AlbumGenres", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.AlbumGenres", new[] { "GenreId" });
            DropIndex("dbo.AlbumGenres", new[] { "AlbumId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            AlterColumn("dbo.Albums", "ArtistId", c => c.Int());
            DropTable("dbo.Songs");
            DropTable("dbo.AlbumGenres");
            RenameColumn(table: "dbo.Albums", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Genres", "Album_Id");
            CreateIndex("dbo.Albums", "Artist_Id");
            AddForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists", "Id");
            AddForeignKey("dbo.Genres", "Album_Id", "dbo.Albums", "Id");
        }
    }
}
