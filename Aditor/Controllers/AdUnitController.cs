using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aditor.Controllers
{
    using System.Runtime.Serialization;

    using Aditor.Models;

    public class AdUnitController : ApiController
    {

        public AdUnitInfo Get(string applicationId, int adType)
        {
            return new BannerInfo()
                   {
                       AdUnitType = adType,
                       AdUrl = "http://google.com.ua",
                       BannerUrl = "http://google.com.ua"
                   };
        }
    }
}
