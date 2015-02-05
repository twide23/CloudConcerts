using CloudConcerts3.DAL;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CloudConcerts3.Controllers
{
    public class HomeController : Controller
    {
        private MusicContext3 db = new MusicContext3();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //var email = User.Identity.GetUserName();
            var id = User.Identity.GetUserId();
            var hosts = from s in db.Hosts
                           select s;
            var listeners = from l in db.Listeners
                            select l;

            //CloudConcerts3.DAL.MusicContext3 db = new CloudConcerts3.DAL.MusicContext3();

            //if (email == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var listener = db.Listeners.SingleOrDefault(lstnr => lstnr.Email == email);
            //var list = db.Listeners.SingleOrDefault(lstnr => lstnr.Id == id);

            //if (listener == null)
            //{
            //    return HttpNotFound();
            //}
            return View(listeners.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}