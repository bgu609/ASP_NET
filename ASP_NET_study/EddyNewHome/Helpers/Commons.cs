using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace EddyNewHome.Helpers
{
    public class Commons
    {
        string whatismyip = "https://www.whatismyip.com/";
        string index = "";

        WebClient wc = new WebClient();
        UTF8Encoding utf8 = new UTF8Encoding();


        public static string GetIpAddress()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addrs = ipEntry.AddressList;

            return addrs[5].ToString();
        }
    }
}