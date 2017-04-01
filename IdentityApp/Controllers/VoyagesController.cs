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
            ViewBag.BusStops = db.BusStops.ToList();
            var model = db.Voyages;
            
            return View(model);
        }
        public ActionResult IndexForUsers()
        {
            ViewBag.BusStops = db.BusStops.ToList();
            var model = db.Voyages;

            return View(model);
        }

        // GET: Voyages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voyage voyage = db.Voyages.Find(id);
            voyage.BusStops = db.BusStops.ToList();
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // GET: Voyages/Create
        public ActionResult Create()
        {
            Voyage model = new Voyage();
            
            model.BusStops = db.BusStops.ToList();
            return View(model);
        }

        // POST: Voyages/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartureBusStopId,ArrivelBusStopId,ArrivelTime,DepartureTime,NumberOfVoyage,NameOfVoyage,CountSeats,Price")] Voyage voyage)
        {
            voyage.TimeInVoyage = (voyage.ArrivelTime - voyage.DepartureTime).TotalHours;
            if (ModelState.IsValid)
            {
                db.Voyages.Add(voyage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            voyage.BusStops = db.BusStops.ToList();
            if (voyage == null)
            {
                return HttpNotFound();
            }
            return View(voyage);
        }

        // POST: Voyages/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartureBusStopId,ArrivelBusStopId,ArrivelTime,DepartureTime,NumberOfVoyage,NameOfVoyage,CountSeats,Price")] Voyage voyage)
        {
            voyage.TimeInVoyage = (voyage.ArrivelTime-voyage.DepartureTime).TotalHours;
            if (ModelState.IsValid)
            {
                db.Entry(voyage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
            voyage.BusStops = db.BusStops.ToList();
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
