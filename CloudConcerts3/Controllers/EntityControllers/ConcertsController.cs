﻿using System;
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
    public class ConcertsController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: Concerts
        public ActionResult Index()
        {
            var concerts = db.Concerts.Include(c => c.Host);
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
            ViewBag.HostID = new SelectList(db.Hosts, "Id", "VenueName");
            return View();
        }

        // POST: Concerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConcertID,Name,Description,HostID,StartTime,EndTime,TicketPrice,isPublic")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                db.Concerts.Add(concert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HostID = new SelectList(db.Hosts, "Id", "VenueName", concert.HostID);
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
            ViewBag.HostID = new SelectList(db.Hosts, "Id", "VenueName", concert.HostID);
            return View(concert);
        }

        // POST: Concerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConcertID,Name,Description,HostID,StartTime,EndTime,TicketPrice,isPublic")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HostID = new SelectList(db.Hosts, "Id", "VenueName", concert.HostID);
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
