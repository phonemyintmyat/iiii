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
    public class menusController : Controller
    {
        private forfoodiesEntities1 db = new forfoodiesEntities1();

        // GET: menus
        public ActionResult Index(int id, string resname)
        {
            var menus = db.menus.Include(m => m.restaurant).Where(x=>x.Restaurantid==id);
            ViewBag.resname = resname;
            return View(menus.ToList());
        }

        // GET: menus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: menus/Create
        public ActionResult Create(int id=0)
        {
            ViewBag.Restaurantname = id;
            return View();
        }

        // POST: menus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Restaurantid,Menu_name,price,Image_menu")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.menus.Add(menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Restaurantid = new SelectList(db.restaurants, "Restaurant_id", "Restaurant_name", menu.Restaurantid);
            return View(menu);
        }

        // GET: menus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Restaurantid = new SelectList(db.restaurants, "Restaurant_id", "Restaurant_name", menu.Restaurantid);
            return View(menu);
        }

        // POST: menus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Restaurantid,Menu_name,price,Image_menu")] menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Restaurantid = new SelectList(db.restaurants, "Restaurant_id", "Restaurant_name", menu.Restaurantid);
            return View(menu);
        }

        // GET: menus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu menu = db.menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            menu menu = db.menus.Find(id);
            db.menus.Remove(menu);
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
