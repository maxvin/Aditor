namespace Aditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCampaignRulesMapping : DbMigration
    {
        public override void Up()
        {
         //   DropPrimaryKey("dbo.Campaignes");
            //DropPrimaryKey("dbo.Rules");
            
            //DropPrimaryKey("dbo.CampaignRuleMapping");
            AddPrimaryKey("dbo.Campaignes", "CampaignId");
            AddPrimaryKey("dbo.Rules", "RuleId");
            AddPrimaryKey("dbo.CampaignRuleMapping", new[] { "CampaignId", "RuleId" });
            AddForeignKey("dbo.CampaignRuleMapping", "CampaignId", "dbo.Campaignes", "CampaignId", true);
            AddForeignKey("dbo.CampaignRuleMapping", "RuleId", "dbo.Rules", "RuleId", true);
            CreateIndex("dbo.CampaignRuleMapping", "CampaignId");
            CreateIndex("dbo.CampaignRuleMapping", "RuleId");

            //DropTable("dbo.CampaignRuleMapping");
            //CreateTable(
            //    "dbo.CampaignRuleMapping",
            //    c => new
            //        {
            //            CampaignId = c.Int(nullable: false),
            //            RuleId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.CampaignId, t.RuleId })
            //    .ForeignKey("dbo.Campaignes", t => t.CampaignId, cascadeDelete: true)
            //    .ForeignKey("dbo.Rules", t => t.RuleId, cascadeDelete: true)
            //    .Index(t => t.CampaignId)
            //    .Index(t => t.RuleId);
            
            AlterColumn("dbo.Campaignes", "CampaignId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Campaignes", "CampaignName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Rules", "RuleId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Rules", "GeoTag", c => c.String(maxLength: 10));
            AlterColumn("dbo.Rules", "Offers", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CampaignRuleMapping", "RuleId", "dbo.Rules");
            DropForeignKey("dbo.CampaignRuleMapping", "CampaignId", "dbo.Campaignes");
            DropIndex("dbo.CampaignRuleMapping", new[] { "RuleId" });
            DropIndex("dbo.CampaignRuleMapping", new[] { "CampaignId" });
            
            DropTable("dbo.CampaignRuleMapping");
            CreateTable(
                "dbo.CampaignRuleMapping",
                c => new
                    {
                        CampaignId = c.Int(nullable: false),
                        RuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CampaignId, t.RuleId });
            
            DropPrimaryKey("dbo.Rules");
            DropPrimaryKey("dbo.Campaignes");
            AlterColumn("dbo.Rules", "Offers", c => c.String(nullable: false, maxLength: 128, unicode: false));
            AlterColumn("dbo.Rules", "GeoTag", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Rules", "RuleId", c => c.Int(nullable: false));
            AlterColumn("dbo.Campaignes", "CampaignName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Campaignes", "CampaignId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Rules", new[] { "RuleId", "GeoTag", "Offers", "RuleIsDefault" });
            AddPrimaryKey("dbo.Campaignes", new[] { "CampaignId", "CampaignName", "CampaignIsDefault" });
        }
    }
}
