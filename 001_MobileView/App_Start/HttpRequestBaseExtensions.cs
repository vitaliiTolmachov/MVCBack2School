using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _001_MobileView.App_Start
{
    public static class HttpRequestBaseExtensions
    {
        public static Boolean IsDesktop(this HttpRequestBase request)
        {
            return true;
        }
        public static bool IsSmartphone(this HttpRequestBase request)
        {
            return IsSmartPhoneInternal(request.UserAgent);
        }

        private static bool IsSmartPhoneInternal(string userAgent)
        {
            var ua = userAgent.ToLower();
            return ua.Contains("ipad") || ua.Contains("gt-");
        }

        public static bool IsTablet(this HttpRequestBase request)
        {
            return IsTabletInternal(request.UserAgent);
        }

        private static bool IsTabletInternal(string userAgent)
        {
            var ua = userAgent.ToLower();
            return ua.Contains("ipad") || ua.Contains("gt-");
        }
    }
}