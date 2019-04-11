using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_01_Trace.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.HttpContext.Trace.Write("Enter Index Action");
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
    }
}