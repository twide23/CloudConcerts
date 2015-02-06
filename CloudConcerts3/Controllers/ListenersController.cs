using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CloudConcerts3.DAL;
using CloudConcerts3.Models;
using System;

namespace CloudConcerts3.Controllers
{
    public class ListenersController : Controller
    {
        private MusicContext3 db = new MusicContext3();

        // GET: Listeners
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StateSortParm = sortOrder == "State" ? "state_desc" : "State";

            if (searchString == null) searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var listeners = from s in db.Listeners
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                listeners = listeners.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString)
                                       || s.City.Contains(searchString)
                                       || s.State.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    listeners = listeners.OrderByDescending(s => s.LastName);
                    break;
                case "State":
                    listeners = listeners.OrderBy(s => s.State);
                    break;
                case "state_desc":
                    listeners = listeners.OrderByDescending(s => s.State);
                    break;
                default:
                    listeners = listeners.OrderBy(s => s.LastName);
                    break;
            }
            return View(listeners.ToList());
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

        //// GET: Listeners/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Listeners/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "FirstName,LastName,City,State,Email")] Listener listener)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Listeners.Add(listener);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(listener);
        //}

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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,City,State")] Listener listener)
        {
            if (ModelState.IsValid)
            {
                Listener original = db.Listeners.Find(listener.Id);
                original.FirstName = listener.FirstName;
                original.LastName = listener.LastName;
                original.City = listener.City;
                original.State = listener.State;
                db.Entry(original).State = EntityState.Modified;
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
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
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
