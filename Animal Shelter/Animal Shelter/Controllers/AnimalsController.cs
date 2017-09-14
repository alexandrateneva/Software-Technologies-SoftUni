namespace Animal_Shelter.Controllers
{
    using Animal_Shelter.Models;
    using System.Linq;
    using System.Web.Mvc;

    public class AnimalsController : Controller
    {
        AnimalShelterDbContext db = new AnimalShelterDbContext();

        public ActionResult Index()
        {
            var category = db.Categories.ToList();

            return View(category);
        }

        public ActionResult Browse(string category)
        {
            var categoryModel = db.Categories.Include("Animals").Single(c => c.Name == category);

            return View(categoryModel);
        }

        public ActionResult Details(int id)
        {
            var animal = db.Animals.Find(id);
            return View(animal);
        }
    }
}