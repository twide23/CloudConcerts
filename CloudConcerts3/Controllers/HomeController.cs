//using CloudConcerts3.DAL;
using CloudConcerts3.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CloudConcerts3.Controllers
{
    public class HomeController : Controller
    {
        private CloudConcertsDataEntities db = new CloudConcertsDataEntities();

        public ActionResult Index()
        {
            var id = User.Identity.GetUserId();
            AspNetUser currentUser = db.AspNetUsers.Find(id);

            return View(currentUser);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var id = User.Identity.GetUserId();
            if (id == null)
            {
                return View();
            }

            var currentUser = db.AspNetUsers.Find(id);
            var currentType = currentUser.Type;

            if (User.IsInRole("admin"))
            {
                return View();
            }
            else if (currentType == "Artist")
            {
                var artist = db.Artists.Find(id);
                return View("~/Views/ProfilePartials/_ArtistProfile.cshtml", artist);
            }
            else if (currentType == "Host")
            {
                var host = db.Hosts.Find(id);
                return View("~/Views/ProfilePartials/_HostProfile.cshtml", host);
            }
            else if (currentType == "Listener")
            {
                var listener = db.Listeners.Find(id);
                return View("~/Views/ProfilePartials/_ListenerProfile.cshtml", listener);
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ArtistHome(string id)
        {
            Artist art = db.Artists.Find(id);

            return PartialView("~/Views/ProfilePartials/_ArtistHome.cshtml", art);
        }

        public ActionResult HostHome(string id)
        {
            Host host = db.Hosts.Find(id);

            return PartialView("~/Views/ProfilePartials/_HostHome.cshtml", host);
        }

        public ActionResult ListenerHome(string id)
        {
            Listener listener = db.Listeners.Find(id);

            return PartialView("~/Views/ProfilePartials/_ListenerHome.cshtml", listener);
        }
    }
}