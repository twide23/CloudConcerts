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
using Microsoft.AspNet.Identity;

namespace CloudConcerts3.Controllers
{
    [Authorize(Roles = "admin, host")]
    public class GigsController : Controller
    {
        private MusicContext3 db = new MusicContext3();

        // GET: Gigs
        public ActionResult Index()
        {
            var gigs = db.Gigs.Include(g => g.Host);

            if (User.IsInRole("admin"))
            {
                return View(gigs.ToList());
            }

            var userid = User.Identity.GetUserId();
            gigs = gigs.Where(g => g.HostID.Contains(userid));
            return View(gigs.ToList());
        }

        // GET: Gigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gig gig = db.Gigs.Find(id);
            if (User.IsInRole("admin"))
            {
                return View(gig);
            }

            var userid = User.Identity.GetUserId();
            if (gig == null || gig.HostID != userid)
            {
                return HttpNotFound();
            }
            return View(gig);
        }

        // GET: Gigs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GigID,Name,Time,Date,Description,Compensation,isPublic")] Gig gig)
        {
            if (ModelState.IsValid)
            {
                gig.HostID = User.Identity.GetUserId();
                db.Gigs.Add(gig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gig);
        }

        // GET: Gigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gig gig = db.Gigs.Find(id);
            if (User.IsInRole("admin"))
            {
                return View(gig);
            }

            var userid = User.Identity.GetUserId();
            if (gig == null || gig.HostID != userid)
            {
                return HttpNotFound();
            }
            return View(gig);
        }

        // POST: Gigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GigID,Name,Time,Date,Description,Compensation,isPublic")] Gig gig)
        {
            if (ModelState.IsValid)
            {
                gig.HostID = User.Identity.GetUserId();
                db.Entry(gig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gig);
        }

        // GET: Gigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gig gig = db.Gigs.Find(id);
            if (User.IsInRole("admin"))
            {
                return View(gig);
            }

            var userid = User.Identity.GetUserId();
            if (gig == null || gig.HostID != userid)
            {
                return HttpNotFound();
            }
            return View(gig);
        }

        // POST: Gigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gig gig = db.Gigs.Find(id);
            db.Gigs.Remove(gig);
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
