namespace Spin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingVideo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Videos", new[] { "Artist_Id" });
            DropTable("dbo.Videos");
        }
    }
}
