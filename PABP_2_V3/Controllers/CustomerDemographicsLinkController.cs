using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PABP_2_V3.Controllers
{
    public class CustomerDemographicsLinkController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: CustomerDemographicsLink
        public ActionResult Index(string DemographicsSelection, string CustomerSelection)
        {
            if (DemographicsSelection != null && CustomerSelection != null)
            {
                // TODO Proveriti da li customer postoji proveriti da li demographic id postoji ukoliko oba postoje dodati link
            }

            List<CustomerDemographics> customerDemographics = db.CustomerDemographics.ToList();
            foreach (var item in customerDemographics)
            {
                item.CustomerTypeID = item.CustomerTypeID.TrimEnd(' ');           
            }
            ViewBag.CustomerDemographics = customerDemographics;
            ViewBag.Customers = db.Customers.ToList();


            return View(customerDemographics);


        }

        // TODO Napraviti delete metodu za brisanje linka
    }
}