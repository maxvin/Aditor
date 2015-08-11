namespace Aditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFileId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Banners", "FileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Banners", "FileId", c => c.Int(nullable: false));
        }
    }
}
