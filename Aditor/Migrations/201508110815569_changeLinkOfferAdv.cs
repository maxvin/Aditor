namespace Aditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLinkOfferAdv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "advertiser_advertiserid", c => c.Int());
            CreateIndex("dbo.Offers", "advertiser_advertiserid");
            AddForeignKey("dbo.Offers", "advertiser_advertiserid", "dbo.Advertisers", "advertiserid");
            DropColumn("dbo.Offers", "advertiserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offers", "advertiserId", c => c.Int());
            DropForeignKey("dbo.Offers", "advertiser_advertiserid", "dbo.Advertisers");
            DropIndex("dbo.Offers", new[] { "advertiser_advertiserid" });
            DropColumn("dbo.Offers", "advertiser_advertiserid");
        }
    }
}
