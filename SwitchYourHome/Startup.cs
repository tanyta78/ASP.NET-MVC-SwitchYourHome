using Microsoft.Owin;
using Owin;
using SwitchYourHome.Data;
using SwitchYourHome.Migrations;
using SwitchYourHome.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(SwitchYourHome.Startup))]
namespace SwitchYourHome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
