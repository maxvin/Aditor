using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditor.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Banners")]
    public class Banner : Offer
    {
        public Banner()
        {
            
        }

        public Banner(Offer offer)
        {
            this.Type = offer.Type;
            this.lp = offer.lp;

            this.category = offer.category;
            this.revenuetype = offer.revenuetype;
            this.revenuevalue = offer.revenuevalue;
            this.payouttype = offer.payouttype; 
            this.payoutvalue = offer.payoutvalue;
            this.active = offer.active;
            this.staticvalues = offer.staticvalues;
            this.offername = offer.offername;
        }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}
