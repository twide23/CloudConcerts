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
    public class ListenerArtistsController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: ListenerArtists
        public ActionResult Index()
        {
            var listenerArtists = db.ListenerArtists.Include(l => l.Artist).Include(l => l.Listener);
            return View(listenerArtists.ToList());
        }

        // GET: ListenerArtists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListenerArtist listenerArtist = db.ListenerArtists.Find(id);
            if (listenerArtist == null)
            {
                return HttpNotFound();
            }
            return View(listenerArtist);
        }

        // GET: ListenerArtists/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName");
            ViewBag.ListenerID = new SelectList(db.Listeners, "Id", "FirstName");
            return View();
        }

        // POST: ListenerArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListenerArtistID,ListenerID,ArtistID")] ListenerArtist listenerArtist)
        {
            if (ModelState.IsValid)
            {
                db.ListenerArtists.Add(listenerArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", listenerArtist.ArtistID);
            ViewBag.ListenerID = new SelectList(db.Listeners, "Id", "FirstName", listenerArtist.ListenerID);
            return View(listenerArtist);
        }

        // GET: ListenerArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListenerArtist listenerArtist = db.ListenerArtists.Find(id);
            if (listenerArtist == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", listenerArtist.ArtistID);
            ViewBag.ListenerID = new SelectList(db.Listeners, "Id", "FirstName", listenerArtist.ListenerID);
            return View(listenerArtist);
        }

        // POST: ListenerArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListenerArtistID,ListenerID,ArtistID")] ListenerArtist listenerArtist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listenerArtist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "Id", "StageName", listenerArtist.ArtistID);
            ViewBag.ListenerID = new SelectList(db.Listeners, "Id", "FirstName", listenerArtist.ListenerID);
            return View(listenerArtist);
        }

        // GET: ListenerArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListenerArtist listenerArtist = db.ListenerArtists.Find(id);
            if (listenerArtist == null)
            {
                return HttpNotFound();
            }
            return View(listenerArtist);
        }

        // POST: ListenerArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListenerArtist listenerArtist = db.ListenerArtists.Find(id);
            db.ListenerArtists.Remove(listenerArtist);
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
