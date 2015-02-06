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
    [Authorize(Roles = "admin")]
    public class ConcertsController : Controller
    {
        private MusicContext3 db = new MusicContext3();

        // GET: Concerts
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.VenueSortParm = sortOrder == "Venue" ? "venue_desc" : "Venue";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";

            if (searchString == null) searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var concerts = from s in db.Concerts
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                concerts = concerts.Where(s => s.Host.VenueName.Contains(searchString)
                                       || s.Name.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    concerts = concerts.OrderByDescending(s => s.Name);
                    break;
                case "Venue":
                    concerts = concerts.OrderBy(s => s.Host.VenueName);
                    break;
                case "venue_desc":
                    concerts = concerts.OrderByDescending(s => s.Host.VenueName);
                    break;
                case "Date":
                    concerts = concerts.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    concerts = concerts.OrderByDescending(s => s.Date);
                    break;
                case "Price":
                    concerts = concerts.OrderBy(s => s.TicketPrice);
                    break;
                case "price_desc":
                    concerts = concerts.OrderByDescending(s => s.TicketPrice);
                    break;
                default:
                    concerts = concerts.OrderBy(s => s.Name);
                    break;
            }
            return View(concerts.ToList());
        }

        // GET: Concerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        // GET: Concerts/Create
        public ActionResult Create()
        {
            ViewBag.HostID = new SelectList(db.Hosts, "HostID", "VenueName");
            return View();
        }

        // POST: Concerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConcertID,HostID,Time,Date,Description,TicketPrice,isPublic")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                db.Concerts.Add(concert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HostID = new SelectList(db.Hosts, "HostID", "VenueName", concert.HostID);
            return View(concert);
        }

        // GET: Concerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            ViewBag.HostID = new SelectList(db.Hosts, "HostID", "VenueName", concert.HostID);
            return View(concert);
        }

        // POST: Concerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConcertID,HostID,Time,Date,Description,TicketPrice,isPublic")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HostID = new SelectList(db.Hosts, "HostID", "VenueName", concert.HostID);
            return View(concert);
        }

        // GET: Concerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        // POST: Concerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Concert concert = db.Concerts.Find(id);
            db.Concerts.Remove(concert);
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
