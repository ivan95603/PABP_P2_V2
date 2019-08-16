using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace PABP_2_V3.Controllers
{
    public class CustomerDemographicsLinkController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: CustomerDemographicsLink
        public ActionResult Index(string DemographicsSelection, string CustomerSelection)
        {
            List<CustomerDemographics> customerDemographics = db.CustomerDemographics.ToList();
            foreach (var item in customerDemographics)
            {
                item.CustomerTypeID = item.CustomerTypeID.TrimEnd(' ');
            }

            if (DemographicsSelection != null && CustomerSelection != null)
            {
               // CustomerDemographics csd = customerDemographics.First(s => s.CustomerTypeID == DemographicsSelection);
               // Customers csm = db.Customers.First(s => s.CustomerID == CustomerSelection);
                
                if ((customerDemographics.First(s => s.CustomerTypeID == DemographicsSelection) != null) && (db.Customers.First(s => s.CustomerID == CustomerSelection) != null))
                {
                    db.CustomerDemographics.Find(DemographicsSelection).Customers.Add(db.Customers.First(s => s.CustomerID == CustomerSelection));
                    db.SaveChanges();
                }              
            }


            ViewBag.CustomerDemographics = customerDemographics;
            ViewBag.Customers = db.Customers.ToList();


            return View(customerDemographics);
        }


        public ActionResult Delete(string CustomerTypeID, string CustomerID)
        {
            if ((CustomerTypeID == null) || (CustomerID == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            CustomerDemographics customerDemographics = db.CustomerDemographics.Find(CustomerTypeID);
            if (customerDemographics == null)
            {
                return HttpNotFound();
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine(CustomerTypeID + " || " + CustomerID);
                db.CustomerDemographics.Find(CustomerTypeID).Customers.Remove(db.Customers.Find(CustomerID));
            }
            db.SaveChanges();

            return Redirect("Index");
        }
    }
}