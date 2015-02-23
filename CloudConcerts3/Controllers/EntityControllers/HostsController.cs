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
    public class HostsController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: Hosts
        public ActionResult Index()
        {
            return View(db.Hosts.ToList());
        }

        // GET: Hosts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = db.Hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // GET: Hosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VenueName,Description,Address,Phone,Website")] Host host)
        {
            if (ModelState.IsValid)
            {
                db.Hosts.Add(host);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(host);
        }

        // GET: Hosts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = db.Hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // POST: Hosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VenueName,Description,Address,Phone,Website,ImageURL")] Host host, HttpPostedFileBase imagefile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(host).State = EntityState.Modified;
                if (imagefile != null)
                {
                    host.ImageURL = CloudConcerts3.Models.ImageStorage.UploadBlob(host.ImageURL, imagefile);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(host);
        }

        // GET: Hosts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = db.Hosts.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // POST: Hosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Host host = db.Hosts.Find(id);
            db.Hosts.Remove(host);
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
            Host host = db.Hosts.Find(userid);
            if (host == null)
            {
                return HttpNotFound();
            }
            CloudConcerts3.Models.ImageStorage.DeleteBlob(host.ImageURL);
            host.ImageURL = null;
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
