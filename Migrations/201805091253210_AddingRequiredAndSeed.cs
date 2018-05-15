namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRequiredAndSeed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Artists", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Artists", "Name", c => c.String());
            AlterColumn("dbo.Albums", "Name", c => c.String());
        }
    }
}
