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
    public class ArtistsController : Controller
    {
        private Top2000Entities db = new Top2000Entities();

        // GET: Artists
        public ActionResult Index()
        {
            return View(db.tblArtist.ToList());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArtist tblArtist = db.tblArtist.Find(id);
            if (tblArtist == null)
            {
                return HttpNotFound();
            }
            return View(tblArtist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistID,ArtistName")] tblArtist tblArtist)
        {
            if (ModelState.IsValid)
            {
                db.tblArtist.Add(tblArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblArtist);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArtist tblArtist = db.tblArtist.Find(id);
            if (tblArtist == null)
            {
                return HttpNotFound();
            }
            return View(tblArtist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID,ArtistName")] tblArtist tblArtist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblArtist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblArtist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblArtist tblArtist = db.tblArtist.Find(id);
            if (tblArtist == null)
            {
                return HttpNotFound();
            }
            return View(tblArtist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblArtist tblArtist = db.tblArtist.Find(id);
            db.tblArtist.Remove(tblArtist);
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
