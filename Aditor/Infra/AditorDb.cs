namespace Aditor
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Aditor.Models;

    public partial class AditorDb : DbContext
    {
        public AditorDb()
            : base("name=kozak")
        {
            //Database.SetInitializer<AditorDb>(null);
        }

        public virtual DbSet<Advertiser> Advertisers { get; set; }
        public virtual DbSet<Affiliates> Affiliates { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Clicks> Clicks { get; set; }
        public virtual DbSet<ClicksSummary> ClicksSummary { get; set; }
        public virtual DbSet<Conversions> Conversions { get; set; }
        public virtual DbSet<CountriesDB> CountriesDB { get; set; }
        public virtual DbSet<Deals> Deals { get; set; }
        public virtual DbSet<IPCountry> IPCountry { get; set; }
        public virtual DbSet<leads> leads { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<postbacks> postbacks { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Campaignes> Campaignes { get; set; }
        public virtual DbSet<CampaignRuleMapping> CampaignRuleMapping { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Rules> Rules { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clicks>()
                .Property(e => e.country)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Conversions>()
                .Property(e => e.conversion_Country)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CountriesDB>()
                .Property(e => e.country_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IPCountry>()
                .Property(e => e.country_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Offers>()
                .Property(e => e.revenuevalue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Offers>()
                .Property(e => e.payoutvalue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Rules>()
                .Property(e => e.Offers)
                .IsUnicode(false);
        }
    }
}
