using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudConcerts3.DAL;
using CloudConcerts3.Models;

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
        public ActionResult Artists()
        {
            return View();
        }

        // GET: Browse/Artists/3
        public ActionResult Artists(string id)
        {
            return View();
        }

        // GET: Browse/Hosts
        public ActionResult Hosts()
        {
            return View();
        }

        // GET: Browse/Hosts/3
        public ActionResult Hosts(string id)
        {
            return View();
        }

        // GET: Browse/Listeners
        public ActionResult Listeners()
        {
            return View();
        }

        // GET: Browse/Listeners/3
        public ActionResult Listeners(string id)
        {
            return View();
        }
    }
}