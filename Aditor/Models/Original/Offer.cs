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
    public partial class Offer
    {
        [Key]
        public int offerID { get; set; }

        public virtual Advertiser advertiser { get; set; }

        [StringLength(500)]
        public string lp { get; set; }

        public virtual Category category { get; set; }

        public virtual Deal revenuetype { get; set; }

        public decimal? revenuevalue { get; set; }

        public virtual Deal payouttype { get; set; }

        public decimal? payoutvalue { get; set; }

        [UIHint("YesNo")]
        public bool active { get; set; }

        [StringLength(250)]
        public string staticvalues { get; set; }

        [StringLength(50)]
        public string offername { get; set; }

        public OfferType Type { get; set; }
    }
}
