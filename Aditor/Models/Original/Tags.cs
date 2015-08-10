namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tags
    {
        [Key]
        public int tagid { get; set; }

        public int? affiliateid { get; set; }

        [StringLength(50)]
        public string tagname { get; set; }
    }
}
