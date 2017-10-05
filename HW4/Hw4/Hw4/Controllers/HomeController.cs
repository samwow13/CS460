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
                ViewBag.additionMessage = "Your names are magically lowercase! " + one + " " + two;
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

            string[] totalLength = { "Total Length: " + (user + pass) };

            ViewBag.mess1 = "Username Length: " + user;
            ViewBag.mess2 = "Password Length: " + pass;
            ViewBag.data = totalLength;
            return View();
        }

        public ActionResult LoanCalc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoanCalc(int? startingBalance, double? interest, int? time)
        {

            double i = interest ?? -1.0;
            int t = time ?? -1;
            int s = startingBalance ?? -1;

            if ((i == -1.0) | (t == -1) | (s == -1))
            {
                ViewBag.Error = "Please complete the form before submitting";
                return View();
            }

            double monthlyRate = CalcMonth(s, i, t);

            ViewBag.Sum = Math.Round(monthlyRate * (t * 12), 2);
            ViewBag.Monthly = Math.Round(monthlyRate, 2);

            return View();
        }

        public double CalcMonth(int s, double i, int t)
        {
            {
                double monthInt;
                monthInt = (i / 100) / 12;
                double payment;
                payment = t * 12;


                return s * (monthInt / (1 - Math.Pow((1 + monthInt), -payment)));
            }

        }
    }
}