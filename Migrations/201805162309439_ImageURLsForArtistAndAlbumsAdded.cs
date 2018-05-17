namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageURLsForArtistAndAlbumsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "AlbumImageURL", c => c.String());
            AddColumn("dbo.Artists", "ArtistImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "ArtistImageURL");
            DropColumn("dbo.Albums", "AlbumImageURL");
        }
    }
}
