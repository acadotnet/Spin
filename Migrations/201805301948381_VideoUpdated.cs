namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Videos", new[] { "Artist_Id" });
            RenameColumn(table: "dbo.Videos", name: "Artist_Id", newName: "ArtistId");
            AlterColumn("dbo.Videos", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Videos", "ArtistId");
            AddForeignKey("dbo.Videos", "ArtistId", "dbo.Artists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Videos", new[] { "ArtistId" });
            AlterColumn("dbo.Videos", "ArtistId", c => c.Int());
            RenameColumn(table: "dbo.Videos", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Videos", "Artist_Id");
            AddForeignKey("dbo.Videos", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
