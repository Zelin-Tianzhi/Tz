using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http;
using Tz.Core;

namespace Tz.WebSite
{
    public class ArgumentsSignFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            if (context.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return; 
            }
            var log = LogFactory.GetLogger(context.RequestContext.ToString());
            log.Info(context.Request.RequestUri.ToString());
            
        }
    }
}