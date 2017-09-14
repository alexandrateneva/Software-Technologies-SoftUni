namespace Animal_Shelter.Controllers
{
    using Microsoft.AspNet.Identity;
    using Animal_Shelter.Models;
    using System.Linq;
    using System.Web.Mvc;
    using System.Data.Entity;

    public class ArticleController : Controller
    {
        public ActionResult List()
        {
            using (var db = new AnimalShelterDbContext())
            {
                var articles = db.Articles
                    .Include(a => a.Author)
                    .ToList();

                return View(articles);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Article model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AnimalShelterDbContext())
                {
                    var authorId = User.Identity.GetUserId();

                    model.AuthorId = authorId;

                    db.Articles.Add(model);
                    db.SaveChanges();
                }

                return RedirectToAction("List");
            }

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            using (var db = new AnimalShelterDbContext())
            {
                var article = db.Articles
                    .Include(a => a.Author)
                    .Where(a => a.Id == id)
                    .FirstOrDefault();

                if (article == null)
                {
                    return HttpNotFound();
                }

                return View(article);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            using (var db = new AnimalShelterDbContext())
            {
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .FirstOrDefault();


                if (article == null || !IsAuthorized(article))
                {
                    return HttpNotFound();
                }

                return View(article);
            }
        }

        [Authorize]
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult ConfirmDelete(int? id)
        {
            using (var db = new AnimalShelterDbContext())
            {
                var article = db.Articles
                    .Where(a => a.Id == id)
                    .FirstOrDefault();

                if (article == null || !IsAuthorized(article))
                {
                    return HttpNotFound();
                }

                db.Articles.Remove(article);
                db.SaveChanges();

                return RedirectToAction("List");
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            using (var db = new AnimalShelterDbContext())
            {
                var article = db.Articles
                   .Where(a => a.Id == id)
                   .FirstOrDefault();

                if (article == null || !IsAuthorized(article))
                {
                    return HttpNotFound();
                }

                var articleViewModel = new ArticleViewModel
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    AuthorId = article.AuthorId
                };

                return View(articleViewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AnimalShelterDbContext())
                {
                    var article = db.Articles
                        .FirstOrDefault(a => a.Id == model.Id);

                    if (article == null || !IsAuthorized(article))
                    {
                        return HttpNotFound();
                    }

                    article.Title = model.Title;
                    article.Content = model.Content;

                    db.SaveChanges();
                }

                return RedirectToAction("Details", new { id = model.Id });
            }

            return View(model);
        }

        private bool IsAuthorized(Article article)
        {
            var isAdmin = this.User.IsInRole("Administrators");
            var isAuthor = article.IsAuthor(this.User.Identity.GetUserId());

            return isAdmin || isAuthor;
        }
    }
}