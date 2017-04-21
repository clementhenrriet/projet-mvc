using projet_clement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_clement.Controllers
{
    public class SuppressionArticleController : Controller
    {
        private readonly MvcEntities db = new MvcEntities(); //permet l'acces à la base de donnée. Essaye de le supprimer pour voir

        // GET: SuppressionArticle
        [HttpGet]
        public ActionResult SuppressionArticle()
        {
            var TousLesArticles = db.articles.Where(x => x.titre != null);

            var model = new HomeModel(TousLesArticles);

            return View(model);
        }

        [HttpPost]
        public ActionResult SuppressionArticle(string titre)
        {
            var id = db.articles.Single(x => x.titre == titre);
            db.articles.Remove(id);
            db.SaveChanges();

            return RedirectToAction("SuppressionArticle", "SuppressionArticle");
        }
    }
}