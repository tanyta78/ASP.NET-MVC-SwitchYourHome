namespace SwitchYourHome.Data
{
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

       public virtual IDbSet<Ad> Ads { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
} 