namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Click
    {
        [StringLength(50)]
        public string ipaddress { get; set; }

        public DateTime? insertdate { get; set; }

        public int? affid { get; set; }

        public int? offerid { get; set; }

        [Column("params")]
        [StringLength(50)]
        public string _params { get; set; }

        [StringLength(500)]
        public string referer { get; set; }

        public int? TagId { get; set; }

        [Key]
        public Guid clickId { get; set; }

        [StringLength(50)]
        public string creative { get; set; }

        [StringLength(50)]
        public string keyword { get; set; }

        [StringLength(50)]
        public string trafficsource { get; set; }

        [StringLength(50)]
        public string campaign { get; set; }

        [StringLength(2)]
        public string country { get; set; }
    }
}
