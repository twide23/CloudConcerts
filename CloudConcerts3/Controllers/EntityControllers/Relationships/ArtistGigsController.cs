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
    public class ArtistGigsController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: ArtistGigs
        public ActionResult Index()
        {
            var artistGigs = db.ArtistGigs.Include(a => a.Artist).Include(a => a.Gig);
            return View(artistGigs.ToList());
        }

        // GET: ArtistGigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistGig artistGig = db.ArtistGigs.Find(id);
            if (artistGig == null)
            {
                return HttpNotFound();
            }
            return View(artistGig);
        }

        // GET: ArtistGigs/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName");
            ViewBag.GigID = new SelectList(db.Gigs, "GigID", "Name");
            return View();
        }

        // POST: ArtistGigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistGigID,ArtistID,GigID")] ArtistGig artistGig)
        {
            if (ModelState.IsValid)
            {
                db.ArtistGigs.Add(artistGig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", artistGig.ArtistID);
            ViewBag.GigID = new SelectList(db.Gigs, "GigID", "Name", artistGig.GigID);
            return View(artistGig);
        }

        // GET: ArtistGigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistGig artistGig = db.ArtistGigs.Find(id);
            if (artistGig == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", artistGig.ArtistID);
            ViewBag.GigID = new SelectList(db.Gigs, "GigID", "Name", artistGig.GigID);
            return View(artistGig);
        }

        // POST: ArtistGigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistGigID,ArtistID,GigID")] ArtistGig artistGig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artistGig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", artistGig.ArtistID);
            ViewBag.GigID = new SelectList(db.Gigs, "GigID", "Name", artistGig.GigID);
            return View(artistGig);
        }

        // GET: ArtistGigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtistGig artistGig = db.ArtistGigs.Find(id);
            if (artistGig == null)
            {
                return HttpNotFound();
            }
            return View(artistGig);
        }

        // POST: ArtistGigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtistGig artistGig = db.ArtistGigs.Find(id);
            db.ArtistGigs.Remove(artistGig);
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
