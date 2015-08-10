namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Affiliates
    {
        [Key]
        public int affiliateid { get; set; }

        [StringLength(50)]
        public string affiliatename { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string affiliateemail { get; set; }

        [StringLength(50)]
        public string affiliatepassword { get; set; }

        public int? affiliatetype { get; set; }
    }
}
