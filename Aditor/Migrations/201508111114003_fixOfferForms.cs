namespace Aditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixOfferForms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "category_categoryID", c => c.Int());
            AddColumn("dbo.Offers", "payouttype_dealID", c => c.Int());
            AddColumn("dbo.Offers", "revenuetype_dealID", c => c.Int());
            AlterColumn("dbo.Offers", "active", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Offers", "category_categoryID");
            CreateIndex("dbo.Offers", "payouttype_dealID");
            CreateIndex("dbo.Offers", "revenuetype_dealID");
            AddForeignKey("dbo.Offers", "category_categoryID", "dbo.Categories", "categoryID");
            AddForeignKey("dbo.Offers", "payouttype_dealID", "dbo.Deals", "dealID");
            AddForeignKey("dbo.Offers", "revenuetype_dealID", "dbo.Deals", "dealID");
            DropColumn("dbo.Offers", "category");
            DropColumn("dbo.Offers", "revenuetype");
            DropColumn("dbo.Offers", "payouttype");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offers", "payouttype", c => c.Int());
            AddColumn("dbo.Offers", "revenuetype", c => c.Int());
            AddColumn("dbo.Offers", "category", c => c.Int());
            DropForeignKey("dbo.Offers", "revenuetype_dealID", "dbo.Deals");
            DropForeignKey("dbo.Offers", "payouttype_dealID", "dbo.Deals");
            DropForeignKey("dbo.Offers", "category_categoryID", "dbo.Categories");
            DropIndex("dbo.Offers", new[] { "revenuetype_dealID" });
            DropIndex("dbo.Offers", new[] { "payouttype_dealID" });
            DropIndex("dbo.Offers", new[] { "category_categoryID" });
            AlterColumn("dbo.Offers", "active", c => c.Boolean());
            DropColumn("dbo.Offers", "revenuetype_dealID");
            DropColumn("dbo.Offers", "payouttype_dealID");
            DropColumn("dbo.Offers", "category_categoryID");
        }
    }
}
