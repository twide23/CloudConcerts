using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudConcerts3.DAL;
using CloudConcerts3.Models;
using System.Web.Services;

namespace CloudConcerts3.Controllers
{
    public class BrowseController : Controller
    {
        private MusicContext3 db = new MusicContext3();

        // GET: Browse
        public ActionResult Index()
        {
            return View();
        }

        // GET: Browse/Artists
        public ActionResult Artists(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.GenreSortParm = sortOrder == "Genre" ? "genre_desc" : "Genre";

            if (searchString == null) searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;

            var artists = from s in db.Artists
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(s => s.StageName.Contains(searchString)
                                       || s.Description.Contains(searchString)
                                       || s.Genre.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    artists = artists.OrderByDescending(s => s.StageName);
                    break;
                case "Genre":
                    artists = artists.OrderBy(s => s.Genre.Name);
                    break;
                case "genre_desc":
                    artists = artists.OrderByDescending(s => s.Genre.Name);
                    break;
                default:
                    artists = artists.OrderBy(s => s.StageName);
                    break;
            }

            return View(artists.ToList());
        }

        // GET: Browse/Hosts
        public ActionResult Hosts(string sortOrder, string currentFilter, string searchString)
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

        // GET: Browse/Concerts
        public ActionResult Concerts(string sortOrder, string currentFilter, string searchString)
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

        // GET: Browse/Calendar
        public ActionResult Calendar()
        {
            var concerts = from s in db.Concerts
                           select s;
            return View(concerts.ToList());
        }

        [HttpPost]
        public ActionResult ViewConcerts()
        {
            MusicContext3 concertDB = new MusicContext3();
            var concerts = from s in concertDB.Concerts
                           select s;
            return Json(concerts.ToList());
        }
    }
}