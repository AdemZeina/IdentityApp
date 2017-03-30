using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using IdentityApp.Models.BuisnessModels;

namespace IdentityApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
        public System.DateTime BirthDay { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }
    
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public ApplicationContext()
            : base("IdentityDb")
        {
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
    
}