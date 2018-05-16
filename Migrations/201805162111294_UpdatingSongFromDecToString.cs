namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingSongFromDecToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "SongLength", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "SongLength", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
