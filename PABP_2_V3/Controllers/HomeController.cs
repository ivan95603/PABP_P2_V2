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
            //s
        //public ActionResult About()
        //{
            
        //    var a = from c in nVE.Invoices
        //            select c.ShipName;
        //    string text = "";
        //    foreach (var item in a.ToList())
        //    {
        //        text += item;
        //    }
        //    ViewBag.Message = text;

        //    return View();
        //}



        /**
         * TRECA STAVKA
         * 
         */
        //public string ispisiZaposlene()
        //{
        //    List<Employees> employees = nVE.Employees.ToList();
        //    string temp = "";
        //    /*Dictionary<string, string> dict = new Dictionary<string, string>();

        //    List<string> regioni = (from x in employees
        //                            select (x.Region)
                                   
        //                            ).Distinct().ToList();
        //                            */
        //    foreach (var item in nVE.Region)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Region: " + item.RegionDescription);
        //        foreach (var item2 in item.Territories)
        //        {
        //            System.Diagnostics.Debug.WriteLine("Teritorija: " + item2.TerritoryDescription + ", BrojZaposlenih: " + item2.Employees.Count());
        //        }
        //    }

        //   /* var linq = (from x in nVE.Employees
        //                group x by new { x.Region, x.Territories } into g
        //                orderby g.Key.
        //                select new { Region = g.Key, Teritorija = g.Key.TerritoryDescription, NoOfEmployees = g.Key.TerritoryDescription.Count() }
        //    ).ToList();
        //    foreach (var item in linq)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Region: " + item.Region+ " Teritorija: " + item.Teritorija + " Count: " + item.NoOfEmployees);
        //    }*/

        //  /*  foreach (var item in regioni)
        //    {
        //        foreach (var item2 in nVE.Territories)
        //        {

        //        }
                
        //            //hocu teritorije gde je region jednak ovome i distinct
               
        //        System.Diagnostics.Debug.WriteLine("-------------------------- ");

        //    }*/

        //    //dict.Keys
        //   /* foreach (String item in regioni)
        //    {
        //        temp += "Region: " + item + "\n";
        //        var result2 = nVE.Employees.Where(b => b.Region == item).ToList();
        //        temp += "Broj zaposlenih " + result2.Count();
        //        temp += "\n";
        //    }*/
        //    return temp;
        //}
        public ActionResult NumberOfEmployees()
        {
            string temp = "";

            //Samo po teritorijama brojanje ne i ukupno po regionima

            //foreach (var item in nVE.Region)
            //{
            //    temp += "<h1>" + item.RegionDescription + "</h1><br>";
            //    foreach (var item2 in item.Territories)
            //    {
            //        temp += "<p>" + "Teritorija: " + item2.TerritoryDescription + ", BrojZaposlenih: " + item2.Employees.Count() + "<p>";    
            //    }
            //}


            //////////////////////////////
            /*
            int trenutniRegionCount = 0;
            string trenutniRegionText = "";
            foreach (var item in nVE.Region)
            {
                foreach (var item2 in item.Territories)
                {
                    trenutniRegionCount += item2.Employees.Count();
                    trenutniRegionText += "<p>" + "Teritorija: " + item2.TerritoryDescription + ", BrojZaposlenih: " + item2.Employees.Count() + "<p>";
                }
                temp += "<h1>" + item.RegionDescription + ", Broj zaposlenih u regionu: " + trenutniRegionCount + "</h1><br>";
                temp += trenutniRegionText;
                trenutniRegionCount = 0;
                trenutniRegionText = "";
            }

            ViewBag.HtmlOutput = temp;
            //return View();

            */

            List<PABP_2_V3.Models.CustomRegionEmployees> regions = new List<Models.CustomRegionEmployees>();
            foreach (Region item in nVE.Region)
            {
                regions.Add(new Models.CustomRegionEmployees(item.RegionDescription, item.Territories.ToList()));

               /* foreach (var item2 in item.Territories)
                {
                    trenutniRegionCount += item2.Employees.Count();
                    trenutniRegionText += "<p>" + "Teritorija: " + item2.TerritoryDescription + ", BrojZaposlenih: " + item2.Employees.Count() + "<p>";
                }
                temp += "<h1>" + item.RegionDescription + ", Broj zaposlenih u regionu: " + trenutniRegionCount + "</h1><br>";
                temp += trenutniRegionText;
                trenutniRegionCount = 0;
                trenutniRegionText = "";*/
            }
            ViewBag.regions = regions;
            int a = 4;
            return View();



            /*   List<Employees> employees = nVE.Employees.ToList();
               //var result = employees.GroupBy(x => new { x.Territories, x.Region }).Count();
               var authorCategoryRecipes =
                   employees
                   .GroupBy(r => new { r.Region, r.Territories})
                   .OrderBy(g => g.Key.Region)
                   .Select(g => new { Region = g.Key.Region, Territories = g.Key.Territories, RecipeCount = g.Count() })
                   .Distinct()
                   .ToList();

               foreach (var item in authorCategoryRecipes)
               {
                   foreach (var item2 in item.Territories)
                   {
                       System.Diagnostics.Debug.WriteLine("Region: " + item.Region + " Teritories: " + item2.TerritoryDescription + "Count: " + item2.Employees.Count);
                   }

               }*/

            /* var q = from d in employees
                      group d by d.Territories into counts
                      select (b fro);*/

            /*    foreach (var item in result)
                {
                    foreach (var item2 in item)
                    {
                        try
                        {
                            System.Diagnostics.Debug.WriteLine(item2.Region, item.Count());
                        }
                        catch (Exception)
                        {

                        }

                    }

                }*/
        }

        /***
         * 
         * CETVRTA STAVKA
         * 
        */

        // http://localhost:12371/Home/ReturnProductsForSuppliersAndCategories/?kategorija=Beverages&kompanija=Exotic%20Liquids
        public ActionResult ReturnProductsForSuppliersAndCategories(string kategorija, string kompanija)
        {
            //string kategorija = "Beverages";
            //string kompanija = "Exotic Liquids";

            List<Categories> categories = nVE.Categories.ToList();
            List<Suppliers> suppliers = nVE.Suppliers.ToList();

            ViewBag.Categories = categories;
            ViewBag.Suppliers = suppliers;
            
            List<Products> products = (from x in nVE.Products
                           where (x.Categories.CategoryName == kategorija && x.Suppliers.CompanyName == kompanija)
                           select x).ToList();

            return View(products);
        }
    }
}