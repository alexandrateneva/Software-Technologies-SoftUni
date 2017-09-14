using Microsoft.Owin;
using Owin;
using Animal_Shelter.Migrations;
using Animal_Shelter.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(Animal_Shelter.Startup))]
namespace Animal_Shelter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AnimalShelterDbContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
