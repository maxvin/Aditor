using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditor.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class OfferCreateViewModel
    {
        public int advertiserId { get; set; }

        [StringLength(500)]
        public string lp { get; set; }

        public int categoryId { get; set; }

        public int revenuetypeId { get; set; }

        public decimal? revenuevalue { get; set; }

        public int payouttypeId { get; set; }

        public decimal? payoutvalue { get; set; }

        [UIHint("YesNo")]
        public bool active { get; set; }

        [StringLength(250)]
        public string staticvalues { get; set; }

        [StringLength(50)]
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

        public List<Deals> DealsList;

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
