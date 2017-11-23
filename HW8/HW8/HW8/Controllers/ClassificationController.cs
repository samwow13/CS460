﻿using HW8.Models;
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
        
        public ActionResult Index()
        {
            return View(db.Classifications.ToList());
        }
    }
}