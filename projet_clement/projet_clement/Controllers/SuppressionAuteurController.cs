using projet_clement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_clement.Controllers
{
    public class SuppressionAuteurController : Controller
    {
        private readonly MvcEntities db = new MvcEntities();

        // GET: SuppressionAuteur
        [HttpGet]
        public ActionResult SuppressionAuteur()
        {
            var allUsers = db.Users.Where(x => x.Nom != null);
            /* recupere dans la base de données User les id de toutes les lignes ou la
             * colonne "nom" n'est pas nulle (ou elle est remplie)
             * */
            var model = new HomeModel(allUsers);
            return View(model);
        }

        [HttpPost]
        public ActionResult SuppressionAuteur(string Nom, string Prenom)
        {

            var userId = db.Users.Single(x => x.Nom == Nom && x.Prenom == Prenom);
            db.Users.Remove(userId);
            db.SaveChanges();

            return RedirectToAction("SuppressionAuteur", "SuppressionAuteur");
        }
    }
}