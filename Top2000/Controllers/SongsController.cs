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
    public class SongsController : Controller
    {
        private Top2000Entities db = new Top2000Entities();

        // GET: Songs
        public ActionResult Index()
        {
            var tblSongs = db.tblSongs.Include(t => t.tblArtist);
            return View(tblSongs.ToList());
        }

        // GET: Songs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSongs tblSongs = db.tblSongs.Find(id);
            if (tblSongs == null)
            {
                return HttpNotFound();
            }
            return View(tblSongs);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.tblArtist, "ArtistID", "ArtistName");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SongID,ArtistID,SongName,SongYear")] tblSongs tblSongs)
        {
            if (ModelState.IsValid)
            {
                db.tblSongs.Add(tblSongs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.tblArtist, "ArtistID", "ArtistName", tblSongs.ArtistID);
            return View(tblSongs);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSongs tblSongs = db.tblSongs.Find(id);
            if (tblSongs == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.tblArtist, "ArtistID", "ArtistName", tblSongs.ArtistID);
            return View(tblSongs);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongID,ArtistID,SongName,SongYear")] tblSongs tblSongs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSongs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.tblArtist, "ArtistID", "ArtistName", tblSongs.ArtistID);
            return View(tblSongs);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSongs tblSongs = db.tblSongs.Find(id);
            if (tblSongs == null)
            {
                return HttpNotFound();
            }
            return View(tblSongs);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSongs tblSongs = db.tblSongs.Find(id);
            db.tblSongs.Remove(tblSongs);
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
