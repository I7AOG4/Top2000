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
    public class RankingsController : Controller
    {
        private Top2000Entities db = new Top2000Entities();

        // GET: Rankings
        public ActionResult Index()
        {
			//var tblRanking = db.tblRanking.Include(t => t.tblSongs);
			//return View(tblRanking.ToList());
			var data = db.spSongList(2018);
			return View(data.ToList());
        }

        // GET: Rankings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRanking tblRanking = db.tblRanking.Find(id);
            if (tblRanking == null)
            {
                return HttpNotFound();
            }
            return View(tblRanking);
        }

        // GET: Rankings/Create
        public ActionResult Create()
        {
            ViewBag.SongID = new SelectList(db.tblSongs, "SongID", "SongName");
            return View();
        }

        // POST: Rankings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RankingID,SongID,RankingPosition,RankingYear")] tblRanking tblRanking)
        {
            if (ModelState.IsValid)
            {
                db.tblRanking.Add(tblRanking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SongID = new SelectList(db.tblSongs, "SongID", "SongName", tblRanking.SongID);
            return View(tblRanking);
        }

        // GET: Rankings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRanking tblRanking = db.tblRanking.Find(id);
            if (tblRanking == null)
            {
                return HttpNotFound();
            }
            ViewBag.SongID = new SelectList(db.tblSongs, "SongID", "SongName", tblRanking.SongID);
            return View(tblRanking);
        }

        // POST: Rankings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RankingID,SongID,RankingPosition,RankingYear")] tblRanking tblRanking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRanking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SongID = new SelectList(db.tblSongs, "SongID", "SongName", tblRanking.SongID);
            return View(tblRanking);
        }

        // GET: Rankings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRanking tblRanking = db.tblRanking.Find(id);
            if (tblRanking == null)
            {
                return HttpNotFound();
            }
            return View(tblRanking);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRanking tblRanking = db.tblRanking.Find(id);
            db.tblRanking.Remove(tblRanking);
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
