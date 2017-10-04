using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hw4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPage()
        {
            if (Request.QueryString.HasKeys())
            {
                string one = Request.QueryString["input1"].Trim().ToLower();
                string two = Request.QueryString["input2"].Trim().ToLower();
                ViewBag.caseHeader = "Your input:";

                one = one.Equals("") ? one : one.First().ToString() + one.Substring(1);
                ViewBag.additionMessage = "Your names are magically lowercase! "  + one + " " + two;
            }
            return View();
        }
        
        public ActionResult PostPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PostPage(FormCollection form)
        {
            int user = form["username"].Length;
            int pass = form["password"].Length;

            string[] totalLength = { "Total Length: " + (user + pass)};

            ViewBag.mess1 = "Username Length: " + user;
            ViewBag.mess2 = "Password Length: " + pass;
            ViewBag.data = totalLength;
            return View();
        }

    }
}