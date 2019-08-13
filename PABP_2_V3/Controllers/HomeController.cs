using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PABP_2_V3.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities nVE = new NorthwindEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            
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
        
        public ActionResult CustomerDemographicsView()
        {
            ViewBag.Message = "Your contact page.";
            var nVE = new NorthwindEntities();
            var a = from c in nVE.CustomerDemographics
                    select c;
            ViewData["Model"] = a.ToList();
            

            return View();
        }

        public ActionResult CustomerDemographicsEdit()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




        /***
         * CETVRTA STAVKA
        */

        public ActionResult ReturnProductsForSuppliersAndCategories()
        {
            string kategorija = "Beverages";
            string kompanija = "Exotic Liquids";
            List<Products> products = (from x in nVE.Products
                           where (x.Categories.CategoryName == kategorija && x.Suppliers.CompanyName == kompanija)
                           select x).ToList();

            return View(products);
        }


    }
}