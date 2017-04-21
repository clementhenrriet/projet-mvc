using projet_clement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_clement.Controllers
{
    public class CreationArticleController : Controller
    {
        private readonly MvcEntities db = new MvcEntities(); //permet l'acces à la base de donnée. Essaye de le supprimer pour voir

        // GET: CreationArticle
        [HttpGet]
        public ActionResult CreationArticle()
        {
            var TousLesArticles = db.articles.Where(x => x.titre != null);
            var allUsers = db.Users.Where(x => x.Nom != null);

            var model = new HomeModel(TousLesArticles, allUsers);

            return View(model);
        }

        [HttpPost]
        public ActionResult CreationArticle(articles formArticles)
        {
            db.articles.Add(formArticles);
            db.SaveChanges();

            return RedirectToAction("CreationArticle", "CreationArticle");
        }
    }
}