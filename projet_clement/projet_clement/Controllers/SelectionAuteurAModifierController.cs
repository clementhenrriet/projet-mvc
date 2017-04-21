using projet_clement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_clement.Controllers
{
    public class SelectionAuteurAModifierController : Controller
    {
        private readonly MvcEntities db = new MvcEntities(); //permet l'acces à la base de donnée. Essaye de le supprimer pour voir

        // GET: SelectionAuteurAModifier
        [HttpGet]
        public ActionResult SelectionAuteurAModifier()
        {
            var allUsers = db.Users.Where(x => x.Nom != null);

            var model = new HomeModel(allUsers);

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectionAuteurAModifier(int userId)
        {
            return RedirectToAction("Edituser", "Home");
        }
    }
}