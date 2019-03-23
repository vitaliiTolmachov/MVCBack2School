using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _001_Aplication_Life_Cycle
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        // обработка события BeginRequest
        protected void Application_BeginRequest()
        {
            AddEvent("BeginRequest");
        }
        // обработка события AuthenticateRequest
        protected void Application_AuthenticateRequest()
        {
            AddEvent("AuthenticateRequest");
        }
        // обработка события PreRequestHandlerExecute
        protected void Application_PreRequestHandlerExecute()
        {
            AddEvent("PreRequestHandlerExecute");
        }

        private void AddEvent(string name)
        {
            List<string> eventList = this.Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }
            eventList.Add(name);
        }

        /////Better implementation
        //protected MvcApplication()
        //{
        //    base.BeginRequest += (src, args) => AddEvent("BeginRequest");
        //    base.AuthenticateRequest += (src, args) => AddEvent("AuthenticateRequest");
        //    base.PreRequestHandlerExecute += (src, args) => AddEvent("PreRequestHandlerExecute");
        //}
        protected void Application_Error()
        {
            Debug.Write("Error!");
        }

        protected void Application_End()
        {
            Debug.Write("App is dead!");
        }

    }
}
