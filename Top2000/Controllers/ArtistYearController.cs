using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Top2000.EF;


namespace Top2000.Controllers
{
    public class ArtistYearController : Controller
    {
        private Top2000Entities db = new Top2000Entities();
        // GET: ArtistYear
        public ActionResult Index()
        {
            var data = db.spArtistRanking("Queen");
            return View(data.ToList());
        }
    }
}