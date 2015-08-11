using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditor.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class OfferViewModel
    {

        public OfferViewModel()
        {
            active = true;
        }

        public OfferViewModel(Offer offer)
        {
            this.Type = offer.Type;
            this.active = offer.active;
            this.advertiserId = offer.advertiser.advertiserid;
            this.categoryId = offer.category.categoryID;
            this.lp = offer.lp;
            this.offerID = offer.offerID;
            this.offername = offer.offername;
            this.payouttypeId = offer.payouttype.dealID;
            this.payoutvalue = offer.payoutvalue;
            this.revenuetypeId = offer.revenuetype.dealID;
            this.revenuevalue = offer.revenuevalue;
            this.staticvalues = offer.staticvalues;
        }

        public int offerID { get; set; }

        [Display(Name = "Advertiser")]
        public int advertiserId { get; set; }

        [StringLength(500)]
        public string lp { get; set; }

        [Display(Name = "Category")]
        public int categoryId { get; set; }

        [Display(Name = "Revenue type")]
        public int revenuetypeId { get; set; }

        public decimal? revenuevalue { get; set; }

        [Display(Name = "Payout type")]
        public int payouttypeId { get; set; }

        public decimal? payoutvalue { get; set; }

        [UIHint("YesNo")]
        public bool active { get; set; }

        [StringLength(250)]
        public string staticvalues { get; set; }

        [StringLength(50)]
        [Required]
        public string offername { get; set; }

        public OfferType Type { get; set; }

        
#region Select Lists

        public List<Advertiser> Advertisers;

        public IEnumerable<SelectListItem> AdvertisersList
        {
            get
            {
                return new SelectList(Advertisers, "advertiserid", "advertisername");
            }
        }

        public List<Category> Categories;

        public IEnumerable<SelectListItem> CategoriesList
        {
            get
            {
                return new SelectList(Categories, "categoryID", "categoryName");
            }
        }

        public List<Deal> DealsList;

        public IEnumerable<SelectListItem> RevenueTypesList
        {
            get
            {
                return new SelectList(DealsList, "dealID", "DealName");
            }
        }
        
        public IEnumerable<SelectListItem> PayoutTypesList
        {
            get
            {
                return new SelectList(DealsList, "dealID", "DealName");
            }
        }

#endregion

    }
}
