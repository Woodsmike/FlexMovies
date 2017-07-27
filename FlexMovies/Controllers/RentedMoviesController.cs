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
    public class RentedMoviesController : Controller
    {
        private FlexMoviesContext db = new FlexMoviesContext();

        // GET: RentedMovies
        public ActionResult Index()
        {
            return View(db.RentedMovies.ToList());
        }

        // GET: RentedMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedMovie rentedMovie = db.RentedMovies.Find(id);
            if (rentedMovie == null)
            {
                return HttpNotFound();
            }
            return View(rentedMovie);
        }

        // GET: RentedMovies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentedMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentedMovieID,ReceiptNumber,CostToRent,RentalDate,ExpirationDate,TimesRented")] RentedMovie rentedMovie)
        {
            if (ModelState.IsValid)
            {
                rentedMovie.ReceiptNumber = rentedMovie.RentedMovieID + 100;
                rentedMovie.RentalDate = DateTime.Now;
                rentedMovie.ExpirationDate = rentedMovie.RentalDate.AddDays(1);
                db.RentedMovies.Add(rentedMovie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentedMovie);
        }

        // GET: RentedMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedMovie rentedMovie = db.RentedMovies.Find(id);
            if (rentedMovie == null)
            {
                return HttpNotFound();
            }
            return View(rentedMovie);
        }

        // POST: RentedMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentedMovieID,ReceiptNumber,CostToRent,RentalDate,ExpirationDate,TimesRented")] RentedMovie rentedMovie)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(rentedMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentedMovie);
        }

        // GET: RentedMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentedMovie rentedMovie = db.RentedMovies.Find(id);
            if (rentedMovie == null)
            {
                return HttpNotFound();
            }
            return View(rentedMovie);
        }

        // POST: RentedMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentedMovie rentedMovie = db.RentedMovies.Find(id);
            db.RentedMovies.Remove(rentedMovie);
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
