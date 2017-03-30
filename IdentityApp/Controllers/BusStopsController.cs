using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityApp.Models;

namespace IdentityApp.Controllers
{
    public class BusStopsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: BusStops
        public ActionResult Index()
        {
            return View(db.BusStops.ToList());
        }

        // GET: BusStops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusStop busStop = db.BusStops.Find(id);
            if (busStop == null)
            {
                return HttpNotFound();
            }
            return View(busStop);
        }

        // GET: BusStops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusStops/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                db.BusStops.Add(busStop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busStop);
        }

        // GET: BusStops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusStop busStop = db.BusStops.Find(id);
            if (busStop == null)
            {
                return HttpNotFound();
            }
            return View(busStop);
        }

        // POST: BusStops/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busStop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busStop);
        }

        // GET: BusStops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusStop busStop = db.BusStops.Find(id);
            if (busStop == null)
            {
                return HttpNotFound();
            }
            return View(busStop);
        }

        // POST: BusStops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusStop busStop = db.BusStops.Find(id);
            db.BusStops.Remove(busStop);
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
