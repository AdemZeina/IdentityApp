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
    public class VoyagesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Voyages
        public ActionResult Index()
        {
            var voyages = db.Voyages.Include(v => v.DepartureBusStop);
            return View(voyages.ToList());
        }

        // GET: Voyages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // GET: Voyages/Create
        public ActionResult Create()
        {
            ViewBag.DepartureBusStopId = new SelectList(db.BusStops, "Id", "Name");
            return View();
        }

        // POST: Voyages/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartureBusStopId,ArrivelBusStopId,ArrivelTime,DepartureTime,TimeInVoyage,NumberOfVoyage,NameOfVoyage,CountSeats,Price")] Voyage voyage)
        {
            if (ModelState.IsValid)
            {
                db.Voyages.Add(voyage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartureBusStopId = new SelectList(db.BusStops, "Id", "Name", voyage.DepartureBusStopId);
            return View(voyage);
        }

        // GET: Voyages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartureBusStopId = new SelectList(db.BusStops, "Id", "Name", voyage.DepartureBusStopId);
            return View(voyage);
        }

        // POST: Voyages/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartureBusStopId,ArrivelBusStopId,ArrivelTime,DepartureTime,TimeInVoyage,NumberOfVoyage,NameOfVoyage,CountSeats,Price")] Voyage voyage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voyage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartureBusStopId = new SelectList(db.BusStops, "Id", "Name", voyage.DepartureBusStopId);
            return View(voyage);
        }

        // GET: Voyages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyage voyage = db.Voyages.Find(id);
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // POST: Voyages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voyage voyage = db.Voyages.Find(id);
            db.Voyages.Remove(voyage);
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
