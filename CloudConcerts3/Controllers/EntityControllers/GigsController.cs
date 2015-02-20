using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudConcerts3.Models;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;

namespace CloudConcerts3.Controllers.EntityControllers
{
    public class GigsController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        // GET: Gigs
        [Authorize(Roles = "admin, host")]
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
        [Authorize(Roles = "admin, host")]
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
        [Authorize(Roles = "admin, host")]
        public ActionResult Create()
        {
            ViewBag.HostID = new SelectList(db.Hosts, "Id", "VenueName");
            return View();
        }

        // POST: Gigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin, host")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GigID,Name,Description,HostID,StartTime,EndTime,Compensation,isPublic")] Gig gig)
        {
            if (ModelState.IsValid)
            {
                if (!User.IsInRole("admin"))
                {
                    gig.HostID = User.Identity.GetUserId();
                }
                db.Gigs.Add(gig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HostID = new SelectList(db.Hosts, "Id", "VenueName", gig.HostID);
            return View(gig);
        }

        // GET: Gigs/Edit/5
        [Authorize(Roles = "admin, host")]
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
        [Authorize(Roles = "admin, host")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GigID,Name,Description,HostID,StartTime,EndTime,Compensation,isPublic")] Gig gig)
        {
            if (ModelState.IsValid)
            {
                if (!User.IsInRole("admin"))
                {
                    gig.HostID = User.Identity.GetUserId();
                }
                db.Entry(gig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HostID = new SelectList(db.Hosts, "Id", "VenueName", gig.HostID);
            return View(gig);
        }

        // GET: Gigs/Delete/5
        [Authorize(Roles = "admin, host")]
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
        [Authorize(Roles = "admin, host")]
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

        // GET: Gigs/Apply
        [Authorize(Roles = "admin, artist")]
        public ActionResult Apply(string sortOrder, string currentFilter, string searchString)
        {
            var userid = User.Identity.GetUserId();
            List<GigViewModel> gigvms = new List<GigViewModel>();

            string query = "SELECT Gig.* "
                + "FROM Gig "
                + "INNER JOIN ArtistGig "
                + "ON Gig.GigID = ArtistGig.GigID AND ArtistGig.ArtistID = @param1";
            IEnumerable<Gig> gigs = db.Database.SqlQuery<Gig>(query, new SqlParameter("param1", userid));
            
            foreach (Gig g in gigs)
            {
                GigViewModel gigvm = CloudConcerts3.Models.ModelMapper.ConvertToGigViewModel(g);
                gigvm.hasUserApplied = true;
                gigvms.Add(gigvm);
            }

            query = "SELECT * "
                + "FROM Gig "
                + "WHERE GigID NOT IN ( "
                    + "SELECT GigID "
                    + "FROM ArtistGig WHERE ArtistID = @param1) ";
            gigs = db.Database.SqlQuery<Gig>(query, new SqlParameter("param1", userid));

            foreach (Gig g in gigs)
            {
                GigViewModel gigvm = CloudConcerts3.Models.ModelMapper.ConvertToGigViewModel(g);
                gigvm.hasUserApplied = false;
                gigvms.Add(gigvm);
            }

            ViewBag.TimeSortParm = String.IsNullOrEmpty(sortOrder) ? "time_desc" : "";
            ViewBag.HostSortParm = sortOrder == "Host" ? "host_desc" : "Host";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.CompSortParm = sortOrder == "Comp" ? "comp_desc" : "Comp";
            ViewBag.PublicSortParm = sortOrder == "Public" ? "public_desc" : "Public";
            ViewBag.sortOrder = sortOrder;

            if (searchString == null) searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                gigvms = gigvms.Where(s => s.Name.ToLower().Contains(searchString.ToLower())
                                       || s.Description.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "time_desc":
                    gigvms = gigvms.OrderByDescending(s => s.StartTime).ToList();
                    break;
                case "Host":
                    gigvms = gigvms.OrderBy(s => s.HostID).ToList();
                    break;
                case "host_desc":
                    gigvms = gigvms.OrderByDescending(s => s.HostID).ToList();
                    break;
                case "Name":
                    gigvms = gigvms.OrderBy(s => s.Name).ToList();
                    break;
                case "name_desc":
                    gigvms = gigvms.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Comp":
                    gigvms = gigvms.OrderBy(s => s.Compensation).ToList();
                    break;
                case "comp_desc":
                    gigvms = gigvms.OrderByDescending(s => s.Compensation).ToList();
                    break;
                case "Public":
                    gigvms = gigvms.OrderBy(s => s.isPublic).ToList();
                    break;
                case "public_desc":
                    gigvms = gigvms.OrderByDescending(s => s.isPublic).ToList();
                    break;
                default:
                    gigvms = gigvms.OrderBy(s => s.StartTime).ToList();
                    break;
            }

            return View(gigvms);
        }

        // GET: Gigs/ApplyForGig/3
        [Authorize(Roles = "admin, artist")]
        public ActionResult ApplyForGig(int id, string sortOrder, string currentFilter, string searchString)
        {
            var userid = User.Identity.GetUserId();
            var dbcheck = db.ArtistGigs.Where(a => a.ArtistID == userid && a.GigID == id);
            var dbcheckcount = dbcheck.Count();
            Gig gg = db.Gigs.Find(id);
            if (dbcheckcount == 0 && gg != null)
            {
                ArtistGig artistGig = new ArtistGig
                {
                    ArtistID = userid,
                    GigID = id
                };
                db.ArtistGigs.Add(artistGig);
                db.SaveChanges();
                return RedirectToAction("Apply", new { sortOrder = sortOrder, currentFilter = currentFilter, searchString = searchString });
            }

            return RedirectToAction("Apply", new { sortOrder = sortOrder, currentFilter = currentFilter, searchString = searchString });
        }
    }
}
