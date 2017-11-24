using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW8.Models;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
        private ArtContext db = new ArtContext();

        // gets the index home page and creates the buttons
        public ActionResult Index()
        {
            return View(db.Genres.OrderBy(g => g.Name).ToList());
        }

        // Backend for Ajax to return Json Data
        public JsonResult GetGenre(int genre)
        {
            var pas = db.Genres.Find(genre).Classifications.ToList().Select(a => new { Piece = a.ArtWorkID, Art = a.ArtWork.ArtistID }).ToList();
            string[] pieceArtist = new string[pas.Count()];
            for (int i = 0; i < pieceArtist.Length; ++i)
            {
                pieceArtist[i] = $"<tr><td>{db.ArtWorks.Find(pas[i].Piece).Title}</td><td>{db.Artists.Find(pas[i].Art).FullName}</td></tr>";
            }
            var data = new
            {
                arr = pieceArtist
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}