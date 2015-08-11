namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Conversion
    {
        [Key]
        public int conversionId { get; set; }

        public Guid? clickId { get; set; }

        public bool? goal1 { get; set; }

        public bool? goal2 { get; set; }

        public bool? goal3 { get; set; }

        public DateTime? goal1date { get; set; }

        public DateTime? goal2date { get; set; }

        public DateTime? goal3date { get; set; }

        public int? conversion_affid { get; set; }

        public int? conversion_offerid { get; set; }

        [StringLength(2)]
        public string conversion_Country { get; set; }

        public int? conversion_tagid { get; set; }

        [StringLength(50)]
        public string conversion_creative { get; set; }

        [StringLength(50)]
        public string conversion_keyword { get; set; }

        [StringLength(50)]
        public string conversion_trafficsource { get; set; }

        [StringLength(50)]
        public string conversion_campaign { get; set; }

        [StringLength(50)]
        public string conversion_params { get; set; }
    }
}
