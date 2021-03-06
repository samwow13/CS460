﻿using HW8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class ArtworkController : Controller
    {
        private ArtContext db = new ArtContext();

        // Returns a view that lists the Artworks table contents
        public ActionResult Index()
        {
            return View(db.ArtWorks.ToList());
        }
    }
}