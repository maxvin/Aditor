namespace Aditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        offerID = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.offerID)
                .ForeignKey("dbo.Offers", t => t.offerID)
                .Index(t => t.offerID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Banners", "offerID", "dbo.Offers");
            DropIndex("dbo.Banners", new[] { "offerID" });
            DropTable("dbo.Banners");
        }
    }
}
