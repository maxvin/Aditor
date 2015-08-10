namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CountriesDB")]
    public partial class CountriesDB
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IP_from { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IP_To { get; set; }

        [StringLength(2)]
        public string country_code { get; set; }

        [StringLength(64)]
        public string country_name { get; set; }
    }
}
