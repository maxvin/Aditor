namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rules
    {
        [Key]
        [Column(Order = 0)]
        public int RuleId { get; set; }

        public string RuleDescription { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string GeoTag { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Offers { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool RuleIsDefault { get; set; }
    }
}
