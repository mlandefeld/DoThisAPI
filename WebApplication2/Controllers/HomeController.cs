using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("stuff");
        }

        public ActionResult About()
        {
            return Content("about");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return Content("contact");
        }
    }
}