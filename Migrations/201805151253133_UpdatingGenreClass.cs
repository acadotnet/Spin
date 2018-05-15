namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingGenreClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "AlbumId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "AlbumId");
        }
    }
}
