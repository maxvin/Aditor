using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditor.Models
{
    using System.Runtime.Serialization;

    [KnownType(typeof(BannerInfo))]
    public class AdUnitInfo
    {
        public int AdUnitType { get; set; }

    }
}
