using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Tz.Core;

namespace Tz.WebSite.API
{
    public class BaseApiController : ApiController
    {
        public Log Log
        {
            get { return LogFactory.GetLogger(this.GetType().ToString()); }
        }
    }
}