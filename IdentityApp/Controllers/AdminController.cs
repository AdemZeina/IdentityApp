using IdentityApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityApp.Models.BuisnessModels;

namespace IdentityApp.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {

        ApplicationContext db = new ApplicationContext();
        // GET: Admin
        public ActionResult Index()
        {

            IList<string> roles = new List<string> ();
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            return View(roles);
            
        }
        public ActionResult IndexForUser()
        {

            
            List<int> orders = db.Orders.Where(o=>o.CustomerId==User.Identity.Name).Select(o=>o.Id).ToList();
            List<Ticket> tickets = new List<Ticket>();
            foreach (var order in orders)
            {
                tickets.Add(db.Tickets.Single(t=>t.OrderId==order));
            }

           
            return View(tickets);

        }
        [HttpGet]
        public ActionResult AsignRole()
        {
            
            
            ApplicationContext db = new ApplicationContext();
           

          

            return View(db.Users.ToList());
            
        }
        [HttpPost]
        public ActionResult AsignRole(string email, string role)
        {
           

                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                var user = db.Users.Single(u => u.Email == email);
                IList<string> roles = userManager.GetRoles(user.Id);
                foreach (var item in roles)
                {
                    userManager.RemoveFromRole(user.Id, item);
                }
               
                userManager.AddToRole(user.Id,role);
                

            

                return RedirectToAction("AsignRole");
        }

       
    }
}