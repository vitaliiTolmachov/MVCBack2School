using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _001_Aplication_Life_Cycle.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            //throw new Exception();

            List<string> events = HttpContext.Application["events"] as List<string>;
            string html = "<ul>";

            foreach (string e in events)
            {
                html += "<li>" + e + "</li>";
                html += "</ul>";
            }
                
            return html;
        }
    }
}