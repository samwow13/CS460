﻿using HW6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Product(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(id);

            if (product == null) 
                return HttpNotFound();

            
            ViewBag.NumOfReviews = product.ProductReviews.Count;
            ViewBag.Rating = ViewBag.NumOfReviews == 0 ? "N/A" : Math.Round(product.ProductReviews.Average(p => p.Rating), 2).ToString() + "/5";

           
            var sizeUnit = product.SizeUnitMeasureCode;
            ViewBag.SizeUnit = sizeUnit == null ? "N/A" : product.SizeUnitMeasureCode.ToLower();

            
            var weightUnit = product.WeightUnitMeasureCode;
            ViewBag.WeightUnit = weightUnit == null ? "N/A" : product.WeightUnitMeasureCode.ToLower();

            return View(product);
        }

        [HttpGet]
        public ActionResult Review(int? id)
        {
            int pid = id ?? -1;
            if (pid == -1) 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(pid);

            if (product == null)
                return HttpNotFound();
            
            ProductReview review = db.ProductReviews.Create();
            review.ProductID = pid;
            review.Product = product;
            review.ReviewDate = review.ModifiedDate = DateTime.Now;

            return View(review);
        }

        [HttpPost]
        public ActionResult Review(ProductReview reviews)
        {
            if (ModelState.IsValid)
            {
                db.ProductReviews.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("Product", new { id = reviews.ProductID });
            }
            reviews.Product = db.Products.Find(reviews.ProductID);
            return View(reviews);
        }


    }
}