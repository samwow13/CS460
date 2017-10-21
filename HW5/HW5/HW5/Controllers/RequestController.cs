using HW5.DAL;
using HW5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class RequestController : Controller
    {
        private RequestContext db = new RequestContext(); // new request context to connect to the database
        
        // index view for the request controller, returns the entries in the DMV records.
        public ActionResult Index()
        {
                     return View(db.Requests.ToList());
        }

        /// <summary>
        /// returns a standard empty form to fill out.
        /// </summary>
        /// <returns>View </returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Method that modify's the database as needed.
        /// </summary>
        /// <param name="request">request params</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }
    }
}