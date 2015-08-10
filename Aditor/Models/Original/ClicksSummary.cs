namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClicksSummary")]
    public partial class ClicksSummary
    {
        [Key]
        public int rowId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? Time { get; set; }

        public int? AdvertiserId { get; set; }

        public int? Affid { get; set; }

        public long? tagId { get; set; }

        public int? clicks { get; set; }

        public int? signups { get; set; }

        public int? conversions { get; set; }

        public int? deposits { get; set; }

        public int? OfferId { get; set; }

        public int? signupsfordate { get; set; }

        public int? conversionsfordate { get; set; }

        public int? depositsfordate { get; set; }
    }
}
