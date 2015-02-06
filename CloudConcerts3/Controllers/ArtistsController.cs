using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudConcerts3.DAL;
using CloudConcerts3.Models;

namespace CloudConcerts3.Controllers
{
    public class ArtistsController : Controller
    {
        private MusicContext3 db = new MusicContext3();

        // GET: Artists
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.GenreSortParm = sortOrder == "Genre" ? "genre_desc" : "Genre";

            if (searchString == null) searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var artists = from s in db.Artists
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(s => s.StageName.Contains(searchString)
                                       || s.Description.Contains(searchString)
                                       || s.Genre.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    artists = artists.OrderByDescending(s => s.StageName);
                    break;
                case "Genre":
                    artists = artists.OrderBy(s => s.Genre.Name);
                    break;
                case "genre_desc":
                    artists = artists.OrderByDescending(s => s.Genre.Name);
                    break;
                default:
                    artists = artists.OrderBy(s => s.StageName);
                    break;
            }
            return View(artists.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        //// GET: Artists/Create
        //public ActionResult Create()
        //{
        //    ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name");
        //    return View();
        //}

        //// POST: Artists/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "StageName,Description,GenreID,Email")] Artist artist)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.Artists.Add(artist);
        //        //db.SaveChanges();
        //        var user = new Artist { UserName = artist.Email, Email = artist.Email, StageName = artist.StageName, Description = artist.Description, GenreID = artist.GenreID };

        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", artist.GenreID);
        //    return View(artist);
        //}

        // GET: Artists/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", artist.GenreID);
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StageName,Description,GenreID")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                Artist original = db.Artists.Find(artist.Id);
                original.StageName = artist.StageName;
                original.Description = artist.Description;
                original.GenreID = artist.GenreID;
                db.Entry(original).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", artist.GenreID);
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
