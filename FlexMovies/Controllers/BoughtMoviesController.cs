using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlexMovies.Models;

namespace FlexMovies.Controllers
{
    public class BoughtMoviesController : Controller
    {
        private FlexMoviesContext db = new FlexMoviesContext();

        // GET: BoughtMovies
        public ActionResult Index()
        {
            var boughtMovies = db.BoughtMovies.Include(b => b.List);
            return View(boughtMovies.ToList());
        }

        // GET: BoughtMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoughtMovie boughtMovie = db.BoughtMovies.Find(id);
            if (boughtMovie == null)
            {
                return HttpNotFound();
            }
            return View(boughtMovie);
        }

        // GET: BoughtMovies/Create
        public ActionResult Create()
        {
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName");
            return View();
        }

        // POST: BoughtMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoughtMovieID,ReceiptNumber,CostToBuy,Bought,BoughtDate,ListID")] BoughtMovie boughtMovie)
        {
            if (ModelState.IsValid)
            {
                db.BoughtMovies.Add(boughtMovie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", boughtMovie.ListID);
            return View(boughtMovie);
        }

        // GET: BoughtMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoughtMovie boughtMovie = db.BoughtMovies.Find(id);
            if (boughtMovie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", boughtMovie.ListID);
            return View(boughtMovie);
        }

        // POST: BoughtMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoughtMovieID,ReceiptNumber,CostToBuy,Bought,BoughtDate,ListID")] BoughtMovie boughtMovie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boughtMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListID = new SelectList(db.Lists, "ListID", "ListName", boughtMovie.ListID);
            return View(boughtMovie);
        }

        // GET: BoughtMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoughtMovie boughtMovie = db.BoughtMovies.Find(id);
            if (boughtMovie == null)
            {
                return HttpNotFound();
            }
            return View(boughtMovie);
        }

        // POST: BoughtMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoughtMovie boughtMovie = db.BoughtMovies.Find(id);
            db.BoughtMovies.Remove(boughtMovie);
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
