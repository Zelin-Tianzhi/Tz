using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using Tz.Core;
using Tz.Core.Security;
using Tz.Data.Extensions;
using Tz.Plugin.Cache;

namespace Tz.WebSite.API
{
    public class UserController : BaseApiController
    {
        [HttpGet, HttpPost]
        public IHttpActionResult MemberRegister(string username, string userpwd, string verify, string yzm, string useryz, string fw)
        {
            Log.Debug("这个是用户注册方法");
            Regex accountRex = new Regex("^[A-Za-z0-9_][A-Za-z0-9_]*$");
            if (!accountRex.IsMatch(username))
            {
                return Json(3);
            }
            Log.Debug("返回token：" + fw);
            string code = Cache.Get(fw)?.ToString();
            Log.Debug("服务器保存的验证码：" + code);
            Log.Debug("用户传递的验证码：" + Md5.md5(yzm.ToLower(), 16));
            string yzmMd5 = Md5.md5(yzm.ToLower(), 16);
            if (code != yzmMd5)
            {
                return Json(2);
            }

            DbHelper helper = new DbHelper("QpAccount");

            string sql = string.Format("select * from account where account='{0}'", username);
            DataSet ds = helper.GetDataTablebySQL(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Json(4);
            }

            string sqlMaxNum = "select MAX(AccountNum) from Account";
            DataSet dsMaxNum = helper.GetDataTablebySQL(sqlMaxNum);
            int num = 100000;
            if (dsMaxNum.Tables[0].Rows.Count > 0)
            {
                num = dsMaxNum.Tables[0].Rows[0][0].ToInt() + 1;
            }

            int len;
            len = verify.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(verify.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }

            byte[] mingwen = YSEncrypt.DecryptData(inputByteArray);

            string str = Encoding.ASCII.GetString(mingwen);


            string account = username;
            string password = userpwd;
            string accounttype = "11";
            string accountsecondtype = "0";
            string sex = "2";
            string nickname = "新手" + num;
            string accountnum = num.ToString();
            string ipaddress = Net.Ip;
            string mac = string.Join(" , ", Tz.Core.Net.GetMacByNetworkInterface());
            string details = "|||0|0|||||||";
            //|密保问题|密保答案|年龄|身高cm|学历|生肖|星座|职业|省|市|
            //string[] userInfo = details.Split('|');
            //string mbwt = userInfo[1];
            //string mbda = userInfo[2];
            //string age = userInfo[3];
            //string sg = userInfo[4];
            //string xl = userInfo[5];
            //string sx = userInfo[6];
            //string xz = userInfo[7];
            //string zy = userInfo[8];
            //string sheng = userInfo[9];
            //string shi = userInfo[10];

            string realname = "";
            string idntirycard = "";
            string telephone = "";
            string parentid = "";
            string Url = GetUrlStr() + string.Format("ysfunction={0}&account={1}&password={2}&accounttype={3}&accountsecondtype={4}&sex={5}&nickname={6}&accountnum={7}&ipaddress={8}&mac={9}&details={10}",
                "register", account, password, accounttype, accountsecondtype, sex, nickname, accountnum, ipaddress, mac, details);
            string msg = HttpMethods.HttpGet(Url);
            Regex rex = new Regex(@"(-\d+|\d+)<");
            int result=0;
            string respson = rex.Match(msg).Groups[1].Value;
            Log.Debug(msg);
            if (respson != "-1" && respson != "-3" && respson != "-999" && respson != "-404")
            {
                result = 0;
            }
            else
            {
                result = respson.ToInt();
            }
            return Json(result);

        }
        [HttpGet,HttpPost]
        public IHttpActionResult TouristLogin(string verify)
        {
            Log.Debug("这个是游客登陆方法");

            string upwd = "c8c8e2585e7555ee27396f4645b415ff";

            Regex accountRex = new Regex("^[A-Za-z0-9_][A-Za-z0-9_]*$");
            int len;
            len = verify.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(verify.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }

            byte[] mingwen = YSEncrypt.DecryptData(inputByteArray);

            string macAddress = Encoding.ASCII.GetString(mingwen);
            DbHelper helper = new DbHelper("QpAccount");
            int rows = 0;
            string uname = string.Empty;
            do
            {
                uname = BuildAccount();
                string sql = string.Format("select * from account where account='{0}'", uname);
                DataSet ds = helper.GetDataTablebySQL(sql);
                rows = ds.Tables[0].Rows.Count;
            } while (rows > 0);
            

            string sqlMaxNum = "select MAX(AccountNum) from Account";
            DataSet dsMaxNum = helper.GetDataTablebySQL(sqlMaxNum);
            int num = 100000;
            if (dsMaxNum.Tables[0].Rows.Count > 0)
            {
                num = dsMaxNum.Tables[0].Rows[0][0].ToInt() + 1;
            }


            string account = uname;
            string password = upwd;
            string accounttype = "11";
            string accountsecondtype = "0";
            string sex = "2";
            string nickname = uname;
            string accountnum = num.ToString();
            string ipaddress = Net.Ip;
            string mac = Net.GetMacAddress();// string.Join(" , ", Tz.Core.Net.GetMacByNetworkInterface());
            string details = "|||0|0|||||||";
            //|密保问题|密保答案|年龄|身高cm|学历|生肖|星座|职业|省|市|
            //string[] userInfo = details.Split('|');
            //string mbwt = userInfo[1];
            //string mbda = userInfo[2];
            //string age = userInfo[3];
            //string sg = userInfo[4];
            //string xl = userInfo[5];
            //string sx = userInfo[6];
            //string xz = userInfo[7];
            //string zy = userInfo[8];
            //string sheng = userInfo[9];
            //string shi = userInfo[10];

            string realname = "";
            string idntirycard = "";
            string telephone = "";
            string parentid = "";
            string Url = GetUrlStr() + string.Format("ysfunction={0}&account={1}&password={2}&accounttype={3}&accountsecondtype={4}&sex={5}&nickname={6}&accountnum={7}&ipaddress={8}&mac={9}&details={10}",
                "register", account, password, accounttype, accountsecondtype, sex, nickname, accountnum, ipaddress, mac, details);
            string msg = HttpMethods.HttpGet(Url);
            Regex rex = new Regex(@"(-\d+|\d+)<");
            string result = "0";
            string respson = rex.Match(msg).Groups[1].Value;
            Log.Debug(msg);
            if (respson != "-1" && respson != "-3" && respson != "-999" && respson != "-404")
            {
                result = "0&" + uname + "&" + upwd;
            }
            else
            {
                result = respson;
            }
            return Json(result);
        }
        
        [HttpGet,HttpPost]
        public IHttpActionResult AccountRegVerify(string loginname)
        {
            DbHelper helper = new DbHelper("QpAccount");

            string sql = string.Format("select accountid from account where account='{0}'", loginname);
            DataSet ds = helper.GetDataTablebySQL(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Json(1);
            }
            return Json(0);
        }

        private string BuildAccount()
        {
            string uname = string.Empty;
            string sFirst = string.Empty;
            string sLast = string.Empty;
            char[] uFirst = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] uLast = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c', 'd', 'e', 'f', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'g', 'h', 'j', 'k', 'm', 'n', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'p', 'q', 'r', 's', 't', 'u', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            Random ran = new Random();
            for (int i = 0; i < 2; i++)
            {
                sFirst += uFirst[ran.Next(uFirst.Length)];
            }
            for (int i = 0; i < 8; i++)
            {
                sLast += uLast[ran.Next(uLast.Length)];
            }

            uname = sFirst + "_" + sLast;
            return uname;
        }

        string GetUrlStr()
        {
            string filePath = System.Web.HttpContext.Current.Server.MapPath("/Configs/GlobConfig.xml");
            string url = XmlHelper.Read(filePath, "configuration/aqiuUrl", "url");
            return url;
        }


    }
}