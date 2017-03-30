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

namespace IdentityApp.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        
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
        [HttpGet]
        public ActionResult AsignRole()
        {
            
            
            ApplicationContext db = new ApplicationContext();
           

          

            return View(db.Users.ToList());
            
        }
        [HttpPost]
        public ActionResult AsignRole(string email, string role)
        {
           

            using (ApplicationContext db = new ApplicationContext())
            {
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                var user = db.Users.Single(u => u.Email == email);
                IList<string> roles = userManager.GetRoles(user.Id);
                foreach (var item in roles)
                {
                    userManager.RemoveFromRole(user.Id, item);
                }
               
                userManager.AddToRole(user.Id,role);
                

            }

                return RedirectToAction("AsignRole");
        }

       
    }
}