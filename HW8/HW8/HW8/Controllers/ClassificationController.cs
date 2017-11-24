using HW8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class ClassificationController : Controller
    {
        private ArtContext db = new ArtContext();
        
        // Creates a table that lists the contents of the classifcations table.
        public ActionResult Index()
        {
            return View(db.Classifications.ToList());
        }
    }
}