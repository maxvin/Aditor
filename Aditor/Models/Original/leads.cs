namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class leads
    {
        [Key]
        public int leadid { get; set; }

        public int? offerid { get; set; }

        [StringLength(100)]
        public string fullname { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(1)]
        public string gender { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        public int? birthday { get; set; }

        public int? birthmonth { get; set; }

        public int? birthyear { get; set; }

        [StringLength(100)]
        public string street { get; set; }

        [StringLength(100)]
        public string city { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(64)]
        public string country { get; set; }

        [StringLength(50)]
        public string postalcode { get; set; }

        public int? conversiontype { get; set; }

        public Guid? clickId { get; set; }

        [StringLength(500)]
        public string postresult { get; set; }

        public DateTime? insertdate { get; set; }

        [StringLength(50)]
        public string ipaddress { get; set; }
    }
}
