using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditor.Models.ViewModels
{
    using System.Web.Mvc;

    public class MobileApplicationViewModel
    {
        public int Id { get; set; }

        public string PackageName { get; set; }

        public int AffilateId { get; set; }

        public List<Affiliate> AllAffiliates { get; set; }

        public List<Campaignes> AllCampaignes { get; set; }

        public int CampaignId { get; set; }

        public IEnumerable<SelectListItem> CampaignesList
        {
            get
            {
                return new SelectList(AllCampaignes, "CampaignId", "CampaignName");
            }
        }

        public IEnumerable<SelectListItem> AffiliatesList
        {
            get
            {
                return new SelectList(AllAffiliates, "affiliateid", "affiliatename");
            }
        }
    }
}
