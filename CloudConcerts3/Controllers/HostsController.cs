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
    public class HostsController : Controller
    {
        private MusicContext3 db = new MusicContext3();

        // GET: Hosts
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString == null) searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var hosts = from s in db.Hosts
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                hosts = hosts.Where(s => s.VenueName.Contains(searchString)
                                       || s.Description.Contains(searchString)
                                       || s.Address.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    hosts = hosts.OrderByDescending(s => s.VenueName);
                    break;
                default:
                    hosts = hosts.OrderBy(s => s.VenueName);
                    break;
            }
            return View(hosts.ToList());
        }

        // GET: Hosts/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Create([Bind(Include = "VenueName,Description,Address,Phone,Website,Email")] Host host)
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
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "VenueName,Description,Address,Phone,Website,Email")] Host host)
        {
            if (ModelState.IsValid)
            {
                db.Entry(host).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(host);
        }

        // GET: Hosts/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
        {
            Host host = db.Hosts.Find(id);
            db.Hosts.Remove(host);
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
