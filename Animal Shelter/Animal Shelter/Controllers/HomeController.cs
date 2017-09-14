namespace Animal_Shelter.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Little friends";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We are online 24 hours.";

            return View();
        }
        public ActionResult Donate()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}