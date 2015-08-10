namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class postbacks
    {
        [Key]
        public int PostbackID { get; set; }

        public int? affid { get; set; }

        public int? offerid { get; set; }

        [StringLength(250)]
        public string postbackurl { get; set; }

        public int? conversionType { get; set; }
    }
}
