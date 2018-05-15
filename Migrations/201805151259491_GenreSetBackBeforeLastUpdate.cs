namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreSetBackBeforeLastUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Genres", "AlbumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "AlbumId", c => c.Int(nullable: false));
        }
    }
}
