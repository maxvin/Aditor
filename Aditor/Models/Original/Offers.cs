// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Offers.cs" company="">
//   N
// </copyright>
// <summary>
//   The offers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Aditor
{
    using System.ComponentModel.DataAnnotations;
    using Aditor.Models;

    /// <summary>
    /// The offers.
    /// </summary>
    public partial class Offers
    {
        [Key]
        public int offerID { get; set; }

        //public Advertiser advertiser { get; set; }

        public int? advertiserId { get; set; }

        [StringLength(500)]
        public string lp { get; set; }

        public int? category { get; set; }

        public int? revenuetype { get; set; }

        public decimal? revenuevalue { get; set; }

        public int? payouttype { get; set; }

        public decimal? payoutvalue { get; set; }

        [UIHint("YesNo")]
        public bool? active { get; set; }

        [StringLength(250)]
        public string staticvalues { get; set; }

        [StringLength(50)]
        public string offername { get; set; }

        public OfferType Type { get; set; }
    }
}
