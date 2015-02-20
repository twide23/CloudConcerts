using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudConcerts3.Models;

namespace CloudConcerts3.Controllers.EntityControllers.Relationships
{
    public class GigGenresController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: GigGenres
        public ActionResult Index()
        {
            var gigGenres = db.GigGenres.Include(g => g.Genre).Include(g => g.Gig);
            return View(gigGenres.ToList());
        }

        // GET: GigGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GigGenre gigGenre = db.GigGenres.Find(id);
            if (gigGenre == null)
            {
                return HttpNotFound();
            }
            return View(gigGenre);
        }

        // GET: GigGenres/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name");
            ViewBag.GigID = new SelectList(db.Gigs, "GigID", "Name");
            return View();
        }

        // POST: GigGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GigGenreID,GigID,GenreID")] GigGenre gigGenre)
        {
            if (ModelState.IsValid)
            {
                db.GigGenres.Add(gigGenre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", gigGenre.GenreID);
            ViewBag.GigID = new SelectList(db.Gigs, "GigID", "Name", gigGenre.GigID);
            return View(gigGenre);
        }

        // GET: GigGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GigGenre gigGenre = db.GigGenres.Find(id);
            if (gigGenre == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", gigGenre.GenreID);
            ViewBag.GigID = new SelectList(db.Gigs, "GigID", "Name", gigGenre.GigID);
            return View(gigGenre);
        }

        // POST: GigGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GigGenreID,GigID,GenreID")] GigGenre gigGenre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gigGenre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", gigGenre.GenreID);
            ViewBag.GigID = new SelectList(db.Gigs, "GigID", "Name", gigGenre.GigID);
            return View(gigGenre);
        }

        // GET: GigGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GigGenre gigGenre = db.GigGenres.Find(id);
            if (gigGenre == null)
            {
                return HttpNotFound();
            }
            return View(gigGenre);
        }

        // POST: GigGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GigGenre gigGenre = db.GigGenres.Find(id);
            db.GigGenres.Remove(gigGenre);
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
