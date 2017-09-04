using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tz.Core;
using Tz.Plugin.Cache;

namespace Tz.WebSite.API
{
    public class UtilitysController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetAuthCode()
        {
            VerifyCode verifyCode = new VerifyCode();
            byte[] bytes = verifyCode.CreateImage();
            string code = verifyCode.ValidationCode;
            return Json((object)code);
        }
    }
}