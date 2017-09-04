﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Tz.Core;
using Tz.Core.Security;
using Tz.Plugin.Cache;

namespace Tz.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var aa = HttpMethods.HttpGetReturnBytes("http://115.238.87.114:11001/VerifyCode.gif");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Recharge()
        {
            return View();
        }

        public ActionResult Activity(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult Reg()
        {

            return View();
        }

        public ActionResult CustomerCenter()
        {
            return View();
        }

        public ActionResult ForgotPwd()
        {
            return View();
        }

        public ActionResult AntiAddiction()
        {
            return View();
        }

        public ActionResult GameRule(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult Trade()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            VerifyCode verifyCode = new VerifyCode();
            byte[] bytes = verifyCode.CreateImage();
            string code = verifyCode.ValidationCode;
            //string str = string.Empty;
            //for (int i = 0; i < bytes.Count(); i++)
            //{
            //    str += bytes[i];
            //    str += ",";
            //}
            //string path = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "a.txt";
            //FileHelper.ExistsFile(path);
            //FileHelper.AppendText(path, "长度：" + bytes.Count()+"\r\n" + str + "\r\n");
            //FileHelper.CreateFile("b.txt", str);
            //string str = "255,216,255,224,0,16,74,70,73,70,0,1,1,1,0,96,0,96,0,0,255,219,0,67,0,8,6,6,7,6,5,8,7,7,7,9,9,8,10,12,20,13,12,11,11,12,25,18,19,15,20,29,26,31,30,29,26,28,28,32,36,46,39,32,34,44,35,28,28,40,55,41,44,48,49,52,52,52,31,39,57,61,56,50,60,46,51,52,50,255,219,0,67,1,9,9,9,12,11,12,24,13,13,24,50,33,28,33,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,50,255,192,0,17,8,0,31,0,91,3,1,34,0,2,17,1,3,17,1,255,196,0,31,0,0,1,5,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,2,3,4,5,6,7,8,9,10,11,255,196,0,181,16,0,2,1,3,3,2,4,3,5,5,4,4,0,0,1,125,1,2,3,0,4,17,5,18,33,49,65,6,19,81,97,7,34,113,20,50,129,145,161,8,35,66,177,193,21,82,209,240,36,51,98,114,130,9,10,22,23,24,25,26,37,38,39,40,41,42,52,53,54,55,56,57,58,67,68,69,70,71,72,73,74,83,84,85,86,87,88,89,90,99,100,101,102,103,104,105,106,115,116,117,118,119,120,121,122,131,132,133,134,135,136,137,138,146,147,148,149,150,151,152,153,154,162,163,164,165,166,167,168,169,170,178,179,180,181,182,183,184,185,186,194,195,196,197,198,199,200,201,202,210,211,212,213,214,215,216,217,218,225,226,227,228,229,230,231,232,233,234,241,242,243,244,245,246,247,248,249,250,255,196,0,31,1,0,3,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,2,3,4,5,6,7,8,9,10,11,255,196,0,181,17,0,2,1,2,4,4,3,4,7,5,4,4,0,1,2,119,0,1,2,3,17,4,5,33,49,6,18,65,81,7,97,113,19,34,50,129,8,20,66,145,161,177,193,9,35,51,82,240,21,98,114,209,10,22,36,52,225,37,241,23,24,25,26,38,39,40,41,42,53,54,55,56,57,58,67,68,69,70,71,72,73,74,83,84,85,86,87,88,89,90,99,100,101,102,103,104,105,106,115,116,117,118,119,120,121,122,130,131,132,133,134,135,136,137,138,146,147,148,149,150,151,152,153,154,162,163,164,165,166,167,168,169,170,178,179,180,181,182,183,184,185,186,194,195,196,197,198,199,200,201,202,210,211,212,213,214,215,216,217,218,226,227,228,229,230,231,232,233,234,242,243,244,245,246,247,248,249,250,255,218,0,12,3,1,0,2,17,3,17,0,63,0,245,7,214,175,181,77,70,225,124,61,99,5,194,192,251,62,219,59,98,16,113,146,6,57,111,76,174,59,30,65,171,62,25,251,68,150,163,251,84,121,90,170,202,207,34,44,133,75,224,99,113,81,128,70,31,156,110,92,145,208,140,46,46,137,121,14,159,162,75,165,53,229,166,159,125,105,115,42,121,237,39,14,220,141,229,120,221,193,192,221,145,242,131,142,48,32,240,230,159,112,124,68,186,133,164,255,0,109,182,49,226,75,235,213,249,158,64,49,251,188,252,192,96,227,158,56,97,216,87,58,169,102,159,115,73,65,89,163,191,43,13,204,99,114,199,42,103,35,32,48,175,57,185,248,139,174,106,55,23,95,240,139,232,6,250,205,9,72,174,89,24,229,144,110,114,202,49,128,70,54,130,65,39,212,157,163,177,144,37,238,157,44,81,19,104,110,109,204,105,52,101,161,120,213,129,193,25,25,70,4,231,4,2,14,51,94,97,160,120,195,81,240,22,143,113,225,221,79,195,215,71,81,243,165,77,62,120,45,142,203,201,115,129,156,237,46,55,20,1,151,36,169,81,129,129,159,75,13,5,81,54,149,218,232,115,75,67,213,124,61,174,218,248,139,69,183,212,109,93,8,145,64,146,48,217,49,73,129,185,15,3,145,244,25,24,61,8,171,118,247,223,105,113,229,192,230,60,202,173,40,116,101,86,71,217,131,134,39,39,146,56,227,105,13,180,241,94,93,240,158,242,242,235,71,214,39,86,142,63,62,113,182,250,72,140,146,60,228,2,85,249,203,1,144,126,174,220,243,93,190,165,227,13,47,77,191,254,206,185,191,182,183,185,151,112,134,66,76,139,25,194,99,205,81,130,153,46,78,9,198,20,146,195,165,69,90,124,181,92,35,208,47,101,118,107,23,91,171,219,73,161,33,225,17,153,4,171,202,176,97,129,130,56,62,191,74,135,84,130,105,245,13,42,88,227,45,29,164,242,92,202,195,29,60,153,35,10,7,82,196,200,8,227,24,83,146,14,1,158,61,74,214,89,226,142,41,60,197,150,35,42,74,159,52,108,6,63,140,113,159,152,16,59,142,71,67,84,36,186,150,70,139,200,137,148,189,218,155,149,121,142,2,5,234,164,54,84,101,87,128,164,49,36,17,134,103,92,110,187,148,155,47,216,31,34,222,222,217,195,137,25,25,254,227,96,12,142,9,198,1,249,135,7,147,206,51,131,139,153,172,75,217,180,61,38,11,237,70,227,109,188,126,80,23,50,40,101,5,67,59,1,199,114,210,63,78,88,183,122,243,93,11,92,241,66,234,23,55,182,241,197,55,134,164,154,89,218,254,88,240,201,107,20,142,204,55,47,206,14,24,237,86,201,244,0,3,73,202,61,10,81,111,99,216,165,144,199,19,186,198,210,178,169,33,16,128,88,250,12,144,50,125,200,20,144,201,35,193,27,73,26,135,101,5,132,111,185,65,199,56,39,25,30,248,21,201,120,91,199,62,30,241,82,127,103,218,72,208,76,16,98,218,102,8,237,146,249,85,249,178,196,4,220,113,145,134,25,57,200,29,138,168,85,10,160,5,3,0,14,212,110,43,52,236,204,91,221,27,72,187,188,123,171,237,61,76,193,182,135,118,255,0,91,242,142,112,15,32,116,228,118,61,176,76,177,73,5,178,11,116,116,242,153,178,168,126,101,65,216,113,194,168,236,59,83,245,219,215,211,172,34,184,138,56,221,218,242,214,15,222,12,128,178,207,28,108,126,184,115,143,124,117,167,107,23,113,104,250,13,229,224,182,89,35,182,133,164,242,65,218,27,28,227,161,199,229,75,151,93,6,174,236,140,237,78,223,81,188,210,153,116,201,45,109,46,217,88,172,172,161,146,55,237,145,156,28,231,208,227,57,32,244,60,77,222,159,241,7,196,214,71,71,191,211,180,123,27,59,150,217,114,202,222,99,66,163,12,27,105,145,134,79,59,113,206,70,126,94,26,189,46,77,57,26,229,37,71,49,168,32,178,1,195,96,96,125,7,181,36,182,99,122,205,29,165,187,78,173,177,88,185,83,229,179,46,254,66,231,56,25,219,208,149,3,35,168,210,156,253,158,209,79,212,151,169,207,232,62,15,181,240,214,157,21,149,156,115,188,113,92,53,192,102,156,238,121,10,149,203,1,242,145,183,0,12,118,7,168,205,114,62,39,209,180,171,77,67,76,153,236,93,173,117,27,246,146,246,234,71,32,228,177,33,119,227,10,191,59,100,12,18,16,114,8,205,122,99,69,27,92,77,104,103,185,204,137,191,135,219,177,120,92,41,28,142,121,207,94,122,246,174,31,226,192,150,31,14,192,114,126,205,29,200,99,242,15,153,138,200,120,57,206,70,14,114,57,220,48,120,53,84,156,229,86,237,189,72,169,110,71,228,115,186,31,141,116,175,9,234,115,105,198,105,111,52,217,29,126,207,114,225,219,201,92,228,130,132,140,0,89,178,85,65,36,30,15,0,119,179,235,250,74,104,211,107,163,82,142,234,27,55,145,76,182,241,238,33,183,99,96,198,7,241,0,9,236,65,207,59,142,56,210,167,215,124,29,22,157,226,111,39,70,89,46,81,227,182,210,215,104,216,206,18,53,124,110,83,151,124,241,254,201,56,193,174,133,180,77,23,65,208,6,158,44,162,254,205,146,226,36,104,60,161,32,121,36,149,85,89,183,231,118,24,175,39,56,0,99,160,20,85,228,147,210,247,254,181,232,42,92,203,71,177,230,250,222,167,121,241,2,226,238,203,77,186,138,207,68,179,249,167,188,185,109,130,103,195,20,47,158,66,101,78,61,0,220,121,192,18,69,226,175,19,105,90,69,191,129,95,74,123,93,113,227,75,104,46,119,252,162,38,221,251,192,83,166,197,192,220,51,209,137,57,82,15,85,125,224,68,209,95,80,213,124,47,12,159,218,215,17,178,69,19,186,8,33,36,134,44,163,3,7,229,194,140,144,25,134,64,92,227,156,248,124,207,174,124,70,213,175,60,67,35,182,185,98,165,109,224,12,76,112,128,89,36,3,25,24,93,192,14,78,119,19,201,228,115,242,219,67,175,153,53,126,136,236,124,19,225,93,51,194,122,124,86,240,70,151,55,238,93,101,191,22,197,89,242,119,5,39,45,181,64,85,24,206,9,25,234,107,175,195,127,120,126,85,94,43,118,71,207,156,64,243,76,132,34,40,12,8,35,105,227,159,92,140,28,129,219,32,217,171,177,141,239,169,255,217";
            //var aa = str.Split(',');
            //byte[] buffs = new byte[aa.Length];
            //for (int i = 0; i < aa.Length; i++)
            //{
            //    buffs[i] = (byte)aa[i].ToInt();
            //}
            byte[] result = YSEncrypt.EncryptFishFile(bytes);
            //string ss = string.Empty;
            //for (int i = 0; i < result.Count(); i++)
            //{
            //    ss += result[i];
            //    ss += ",";
            //}
            //FileHelper.AppendText(path, "长度：" + result.Count()+"\r\n" + ss + "\r\n");
            return File(result, @"image/Gif");
        }
    }
}