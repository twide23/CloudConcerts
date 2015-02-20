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
    public class ListenerGenresController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: ListenerGenres
        public ActionResult Index()
        {
            var listenerGenres = db.ListenerGenres.Include(l => l.Genre).Include(l => l.Listener);
            return View(listenerGenres.ToList());
        }

        // GET: ListenerGenres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListenerGenre listenerGenre = db.ListenerGenres.Find(id);
            if (listenerGenre == null)
            {
                return HttpNotFound();
            }
            return View(listenerGenre);
        }

        // GET: ListenerGenres/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name");
            ViewBag.ListenerID = new SelectList(db.Listeners, "Id", "FirstName");
            return View();
        }

        // POST: ListenerGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListenerGenreID,ListenerID,GenreID")] ListenerGenre listenerGenre)
        {
            if (ModelState.IsValid)
            {
                db.ListenerGenres.Add(listenerGenre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", listenerGenre.GenreID);
            ViewBag.ListenerID = new SelectList(db.Listeners, "Id", "FirstName", listenerGenre.ListenerID);
            return View(listenerGenre);
        }

        // GET: ListenerGenres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListenerGenre listenerGenre = db.ListenerGenres.Find(id);
            if (listenerGenre == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", listenerGenre.GenreID);
            ViewBag.ListenerID = new SelectList(db.Listeners, "Id", "FirstName", listenerGenre.ListenerID);
            return View(listenerGenre);
        }

        // POST: ListenerGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListenerGenreID,ListenerID,GenreID")] ListenerGenre listenerGenre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listenerGenre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", listenerGenre.GenreID);
            ViewBag.ListenerID = new SelectList(db.Listeners, "Id", "FirstName", listenerGenre.ListenerID);
            return View(listenerGenre);
        }

        // GET: ListenerGenres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListenerGenre listenerGenre = db.ListenerGenres.Find(id);
            if (listenerGenre == null)
            {
                return HttpNotFound();
            }
            return View(listenerGenre);
        }

        // POST: ListenerGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListenerGenre listenerGenre = db.ListenerGenres.Find(id);
            db.ListenerGenres.Remove(listenerGenre);
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
