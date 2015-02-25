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
    public class ListenersController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: Listeners
        public ActionResult Index()
        {
            return View(db.Listeners.ToList());
        }

        // GET: Listeners/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listener listener = db.Listeners.Find(id);
            if (listener == null)
            {
                return HttpNotFound();
            }
            return View(listener);
        }

        // GET: Listeners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listeners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,City,State")] Listener listener)
        {
            if (ModelState.IsValid)
            {
                db.Listeners.Add(listener);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listener);
        }

        // GET: Listeners/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listener listener = db.Listeners.Find(id);
            if (listener == null)
            {
                return HttpNotFound();
            }
            return View(listener);
        }

        // POST: Listeners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,City,State,ImageURL")] Listener listener, HttpPostedFileBase imagefile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listener).State = EntityState.Modified;
                if (imagefile != null)
                {
                    listener.ImageURL = CloudConcerts3.Models.ImageStorage.UploadBlob(listener.ImageURL, imagefile);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listener);
        }

        // GET: Listeners/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listener listener = db.Listeners.Find(id);
            if (listener == null)
            {
                return HttpNotFound();
            }
            return View(listener);
        }

        // POST: Listeners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Listener listener = db.Listeners.Find(id);
            CloudConcerts3.Models.ImageStorage.DeleteBlob(listener.ImageURL);
            db.Listeners.Remove(listener);
            AspNetUser user = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteImage(string userid)
        {
            if (userid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listener listener = db.Listeners.Find(userid);
            if (listener == null)
            {
                return HttpNotFound();
            }
            CloudConcerts3.Models.ImageStorage.DeleteBlob(listener.ImageURL);
            listener.ImageURL = null;
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = userid });
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
