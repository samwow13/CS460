using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// returns an actionresult for a basic index from the homecontroller
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}