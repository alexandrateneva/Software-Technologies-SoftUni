namespace Animal_Shelter.Models
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AnimalShelterDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }


        public AnimalShelterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AnimalShelterDbContext Create()
        {
            return new AnimalShelterDbContext();
        }
    }
}