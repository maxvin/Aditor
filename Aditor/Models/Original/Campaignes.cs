namespace Aditor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Campaignes
    { 
        [Key]
        [Column(Order = 0)]
        public int CampaignId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string CampaignName { get; set; }

        public string CampaignDescription { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool CampaignIsDefault { get; set; }
    }
}
