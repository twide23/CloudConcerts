using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudConcerts3.Models;

namespace CloudConcerts3.Controllers.EntityControllers
{
    public class ArtistConcertsController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: ArtistConcerts
        public ActionResult Index()
        {
            var artistConcerts = db.ArtistConcerts.Include(a => a.Artist).Include(a => a.Concert);
            return View(artistConcerts.ToList());
        }

        // GET: ArtistConcerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistConcert artistConcert = db.ArtistConcerts.Find(id);
            if (artistConcert == null)
            {
                return HttpNotFound();
            }
            return View(artistConcert);
        }

        // GET: ArtistConcerts/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName");
            ViewBag.ConcertID = new SelectList(db.Concerts, "ConcertID", "Name");
            return View();
        }

        // POST: ArtistConcerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistConcertID,ArtistID,ConcertID")] ArtistConcert artistConcert)
        {
            if (ModelState.IsValid)
            {
                db.ArtistConcerts.Add(artistConcert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", artistConcert.ArtistID);
            ViewBag.ConcertID = new SelectList(db.Concerts, "ConcertID", "Name", artistConcert.ConcertID);
            return View(artistConcert);
        }

        // GET: ArtistConcerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistConcert artistConcert = db.ArtistConcerts.Find(id);
            if (artistConcert == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", artistConcert.ArtistID);
            ViewBag.ConcertID = new SelectList(db.Concerts, "ConcertID", "Name", artistConcert.ConcertID);
            return View(artistConcert);
        }

        // POST: ArtistConcerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistConcertID,ArtistID,ConcertID")] ArtistConcert artistConcert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistConcert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", artistConcert.ArtistID);
            ViewBag.ConcertID = new SelectList(db.Concerts, "ConcertID", "Name", artistConcert.ConcertID);
            return View(artistConcert);
        }

        // GET: ArtistConcerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistConcert artistConcert = db.ArtistConcerts.Find(id);
            if (artistConcert == null)
            {
                return HttpNotFound();
            }
            return View(artistConcert);
        }

        // POST: ArtistConcerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistConcert artistConcert = db.ArtistConcerts.Find(id);
            db.ArtistConcerts.Remove(artistConcert);
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
