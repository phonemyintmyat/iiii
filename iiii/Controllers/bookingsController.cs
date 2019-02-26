using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iiii.Models;

namespace iiii.Controllers
{
    public class bookingsController : Controller
    {
        private forfoodiesEntities1 db = new forfoodiesEntities1();
        private int resid = 0;

        // GET: bookings
        public ActionResult Index(int id)
        {
            var bookings = db.bookings.Include(b => b.restaurant).Where(x => x.RestaurantID == id);
            resid = id;
            return View(bookings.ToList());
        }

        // GET: bookings/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: bookings/Create
        public ActionResult Create(int id=0)
        {
            //ViewBag.RestaurantID = new SelectList(db.restaurants, "Restaurant_id", "Restaurant_name");
            ViewBag.RestaurantID = id;
            return View();
        }

        // POST: bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantID,BookingID,username,useremail,userphone,Dayselect,selecttime")] booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.BookingID = Guid.NewGuid();
                db.bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = booking.RestaurantID });
            }

            ViewBag.RestaurantID = booking.RestaurantID;
            return View(booking);
        }

        // GET: bookings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantID = new SelectList(db.restaurants, "Restaurant_id", "Restaurant_name", booking.RestaurantID);
            return View(booking);
        }

        // POST: bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantID,BookingID,username,useremail,userphone,Dayselect,selecttime")] booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantID = new SelectList(db.restaurants, "Restaurant_id", "Restaurant_name", booking.RestaurantID);
            return View(booking);
        }

        // GET: bookings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
            
        // POST: bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            booking booking = db.bookings.Find(id);
            db.bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = resid });
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
