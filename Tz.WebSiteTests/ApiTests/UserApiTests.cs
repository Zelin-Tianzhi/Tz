using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tz.WebApi.Api;
using Tz.Core;
using System.Text;
using Tz.Core.Security;

namespace Tz.WebSiteTests.ApiTests
{
    [TestClass]
    public class UserApiTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string url = "http://192.168.1.99:8080/api/user/MemberRegister?username=test0101&userpwd=123123&yzm=1234&useryz=1234&fw=123";
            //url = "http://192.168.1.99:8080/api/user/GetAuthCode";//?username=test0101&userpwd=123123&yzm=1234&useryz=1234&fw=123";
            //url = "http://192.168.1.99:8080/api/Utilitys/GetAuthCode";
            //url = "http://192.168.1.10:11003/YLWebToServerInterface/test";
            

            int accountnum = 100001;
            int account = 1001;
            string pwd = "c8c8e2585e7555ee27396f4645b415ff";
            int sex = 1;
            int accounttype = 1;
            string ip = Net.Ip;
            string mac = string.Join(";", Net.GetMacByNetworkInterface());
            string details = "|||0|0|||||||";
            for (int i = 0; i < 3000; i++)
            {
                account += 1;
                accountnum += 1;
                url = "http://192.168.1.10:11004/flop.cpp?" + string.Format("function={0}&account={1}&password={2}&accounttype={3}&accountsecondtype={4}&sex={5}&nickname={6}&accountnum={7}&ipaddress={8}&mac={9}&details={10}",
                    "register", "w" + account, pwd, accounttype, accounttype, sex, "测试" + account, accountnum, ip, mac, details);
                try
                {
                    string msg = Tz.Core.HttpMethods.HttpGet(url);
                }
                catch (Exception ex)
                {
                    //Log.Error(ex.Message);
                }
            }

        }

        [TestMethod]
        public void TestReg()
        {

            string text = "1";
            //string key = "87654321";
            //string sbuff = DESEncrypt.EncryptHas(text, key);
            //string date = "2017-10-13";
            //DateTime dt = Convert.ToDateTime(date);

            byte[] data = Encoding.ASCII.GetBytes(text);

            byte[] miwen = YSEncrypt.EncryptFishFile(data);
            StringBuilder ret = new StringBuilder();

            foreach (byte b in miwen)
            {
                ret.AppendFormat("{0:X2}", b);
            }
            string mw = ret.ToString();

            int len;
            len = mw.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(mw.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }

            byte[] mingwen = YSEncrypt.DecryptData(inputByteArray);

            string result = Encoding.ASCII.GetString(mingwen);
            //string url = "http://192.168.1.10:11005/api/user/MemberRegister?username=w11111&userpwd=123123&yzm=1231&useryz=1231&fw=1231";
            //UserController user = new UserController();
            //user.MemberRegister("w21111", "123123", "1231", "1231", "1231");
            //string msg = Tz.Core.HttpMethods.HttpGet(url);
        }
    }
}
