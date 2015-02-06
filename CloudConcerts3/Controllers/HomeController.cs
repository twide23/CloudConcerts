using CloudConcerts3.DAL;
using CloudConcerts3.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CloudConcerts3.Controllers
{
    public class HomeController : Controller
    {
        private MusicContext3 db = new MusicContext3();
        private ApplicationDbContext appdb = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var id = User.Identity.GetUserId();
            var users = from l in appdb.Users
                        where l.Id.Equals(id)
                        select l;

            return View(users.FirstOrDefault());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}