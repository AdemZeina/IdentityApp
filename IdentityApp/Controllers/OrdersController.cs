using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityApp.Models;
using IdentityApp.Models.BuisnessModels;

namespace IdentityApp.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Orders
        public ActionResult Index()
        {
            ViewBag.Voyages = db.Voyages.ToList();
            ViewBag.Users = db.Users.ToList();
            return View(db.Orders.ToList());
        }
        [Authorize(Roles ="user,admin")]
        public ActionResult IndexForUsers()
        {

            List<int> orders = db.Orders.Where(o => o.CustomerId == User.Identity.Name).Select(o => o.Id).ToList();
            List<Ticket> tickets = new List<Ticket>();
            foreach (var order in orders)
            {
                tickets.Add(db.Tickets.Single(t => t.OrderId == order));
            }


            return View(tickets);
        }
        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            order.Voyages = db.Voyages.ToList();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [Authorize(Roles = "user,admin")]
        [HttpGet]
        public ActionResult Create(int id)
        {
            Order model = new Order()
            {
                CustomerId = User.Identity.Name,
                VoyageId = id,
                Status = "Забранированно",
                Voyages = db.Voyages.ToList(),
                
                
                
            };

            ViewBag.FreeSeats = db.Tickets.Where(t => t.VoyageId == id && t.Status == "Свободен").Select(t=>t.NumberOfSeat).ToList();
             

            return View(model);
        }

        [Authorize(Roles ="user,admin")]
        [HttpPost]
        // GET: Orders/Create
        public ActionResult Create([Bind(Include = "VoyageId,CustomerId,Status")]Order model,int seat)
        {

                model.SeatNumber = seat;
                db.Orders.Add(model);
                db.SaveChanges();
                var query = db.Tickets.Where(t => t.VoyageId == model.VoyageId && t.NumberOfSeat == seat);
                foreach(var que in query)
                {
                    que.OrderId = db.Orders.Single(o => o.VoyageId == model.VoyageId && o.CustomerId == model.CustomerId && o.SeatNumber==seat).Id;
                    que.Status = "Забронированно";
                    que.CustomerName = db.Users.Single(u => u.UserName == model.CustomerId).Name;
                    que.LastName = db.Users.Single(u => u.UserName == model.CustomerId).LastName;
                }
                db.SaveChanges();

            return RedirectToAction("IndexForUsers");
            
            
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,VoyageId,Status")] Order order)
        //{

            
        //    if (ModelState.IsValid)
        //    {
        //        db.Orders.Add(order);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(order);
        //}

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            order.Voyages = db.Voyages.ToList();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VoyageId,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            order.Voyages = db.Voyages.ToList();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
