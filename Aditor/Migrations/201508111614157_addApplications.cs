namespace Aditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addApplications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        PackageName = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false, identity: true),
                        AdCampaign_CampaignId = c.Int(),
                        Owner_affiliateid = c.Int(),
                    })
                .PrimaryKey(t => t.PackageName)
                .ForeignKey("dbo.Campaignes", t => t.AdCampaign_CampaignId)
                .ForeignKey("dbo.Affiliates", t => t.Owner_affiliateid)
                .Index(t => t.AdCampaign_CampaignId)
                .Index(t => t.Owner_affiliateid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "Owner_affiliateid", "dbo.Affiliates");
            DropForeignKey("dbo.Applications", "AdCampaign_CampaignId", "dbo.Campaignes");
            DropIndex("dbo.Applications", new[] { "Owner_affiliateid" });
            DropIndex("dbo.Applications", new[] { "AdCampaign_CampaignId" });
            DropTable("dbo.Applications");
        }
    }
}
