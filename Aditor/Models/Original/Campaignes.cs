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

        [Column(Order = 1)]
        [StringLength(200)]
        public string CampaignName { get; set; }

        public string CampaignDescription { get; set; }

        [Column(Order = 2)]
        public bool CampaignIsDefault { get; set; }

        public ICollection<Rules> Rules { get; set; }
    }
}
