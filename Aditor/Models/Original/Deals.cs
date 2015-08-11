namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deal
    {
        [Key]
        public int dealID { get; set; }

        [StringLength(150)]
        public string DealName { get; set; }

        [StringLength(250)]
        public string DealDescription { get; set; }
    }
}
