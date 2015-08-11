namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Advertiser
    {
        [Key]
        public int advertiserid { get; set; }

        [StringLength(250)]
        public string advertisername { get; set; }

        [StringLength(150)]
        public string advertiseremail { get; set; }

        [StringLength(250)]
        public string advertiserURL { get; set; }

        [StringLength(250)]
        public string advertiserPostURL { get; set; }

        [StringLength(250)]
        public string advertiserPostBackUrl { get; set; }

        [StringLength(20)]
        public string advertiserpassword { get; set; }
    }
}
