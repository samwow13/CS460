using HW6.Models;
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
        private AdventureWorksContext db = new AdventureWorksContext(); // reference to the dbcontext class

        /// <summary>
        /// This is just a reference to the initial view on when the project starts.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the product categorys from the database</returns>
        public ActionResult Index(int? id)
        {
            var category = db.ProductCategories;
            if (id != null && db.ProductCategories.Find(id) != null)
            {
                ViewBag.ID = id;
            }

            return View(category);
        }

        /// <summary>
        /// Lists the products under a certain subcategory.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <returns>The products that were found under that subcategory</returns>
        public ActionResult Products(int? id, int? page = 1)
        {
            if (id == null || db.ProductSubcategories.Find(id) == null)
                return RedirectToAction("Index");

            var products = db.ProductSubcategories.Find(id).Products.ToList();
            int pageSize = 9; 
            double pagesNum = Math.Ceiling((double)products.Count / pageSize); 

            int pageNumber = page ?? 0;
            if (page < 1 || page > pagesNum) // if page < 1 then no entries were found.
                return HttpNotFound(); 

            ViewBag.NumberOfPages = pagesNum;
            
            var productsPaged = products.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            return View(productsPaged);
        }

        /// <summary>
        /// this method finds all general top category products.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The product view</returns>
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

        /// <summary>
        /// Method to get a review and set its date time.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// this method posts the information to the database.
        /// </summary>
        /// <param name="reviews"></param>
        /// <returns>The view to reviews page</returns>
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