using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6_EncryptConfiguration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.isValidationEnabled = ConfigurationManager.AppSettings["ClientValidationEnabled"];

            return View();
        }
    }
}
