using HW6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        public ActionResult Index(int? id)
        {
            var category = db.ProductCategories;
            if (id != null && db.ProductCategories.Find(id) != null)
            {
                ViewBag.ID = id;
            }

            return View(category);
        }

        public ActionResult Products(int? id, int? page = 1)
        {
            if (id == null || db.ProductSubcategories.Find(id) == null)
                return RedirectToAction("Index");


            var products = db.ProductSubcategories.Find(id).Products.ToList();
            int pageSize = 9; 
            double pagesNum = Math.Ceiling((double)products.Count / pageSize); 

            int pageNumber = page ?? 0;
            if (page < 1 || page > pagesNum)
                return HttpNotFound(); 

            ViewBag.NumberOfPages = pagesNum;
            
            var productsPaged = products.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            return View(productsPaged);
        }
    }
}