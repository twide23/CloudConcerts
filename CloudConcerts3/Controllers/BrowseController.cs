using System;
using System.Linq;
using System.Web.Mvc;
using CloudConcerts3.Models;
using System.Collections.Generic;

namespace CloudConcerts3.Controllers
{
    public class BrowseController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

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
                    concerts = concerts.OrderBy(s => s.StartTime);
                    break;
                case "date_desc":
                    concerts = concerts.OrderByDescending(s => s.StartTime);
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
            var concerts = db.Concerts.Where(c => c.isPublic.Equals(true)).ToList();
            List<ConcertViewModel> ConcertVMS = new List<ConcertViewModel>();
            foreach (var c in concerts)
            {
                var cvm = CloudConcerts3.Models.ModelMapper.ConvertToConcertViewModel(c);
                ConcertVMS.Add(cvm);
            }

            return Json(ConcertVMS.ToArray());
        }
    }
}