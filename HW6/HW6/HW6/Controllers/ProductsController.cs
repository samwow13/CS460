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
            var cat = db.ProductCategories;
            //determine if a ProductCategory was selected
            if (id != null && db.ProductCategories.Find(id) != null)
            {
                ViewBag.ID = id;
            }

            return View(cat);
        }
    }
}