using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PABP_2_V3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var nVE = new NorthwindEntities();
            var a = from c in nVE.Invoices
                    select c.ShipName;
            string text = "";
            foreach (var item in a.ToList())
            {
                text += item;
            }
            ViewBag.Message = text;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}