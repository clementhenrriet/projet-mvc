using projet_clement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_clement.Controllers
{
    public class CreationAuteurController : Controller
    {
        private readonly MvcEntities db = new MvcEntities(); //permet l'acces à la base de donnée. Essaye de le supprimer pour voir

        [HttpGet]
        public ActionResult CreationAuteur()
        {
            var allUsers = db.Users.Where(x => x.Nom != null);
            /* recupere dans la base de données User les id de toutes les lignes ou la
             * colonne "nom" n'est pas nulle (ou elle est remplie)
             * */
            var model = new HomeModel(allUsers);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreationAuteur(Users formUser) /*au lieu de récupérer tous les paramètres 
            un par un, on les mets tous dans un formuser. c'est moins contraignant à écrire si on 
            avait du en récupérer 200*/
        {
            db.Users.Add(formUser); //Ajoute les nouvelles données à la base de donnée
            try
            {
                db.SaveChanges(); //IMPORTANT, penser à sauvegarder
            }
            catch (Exception e)
            {
                RedirectToAction("CreationAuteur", "CreationAuteur"); //premier terme = nom vue, deuxieme terme = nom fichier racine
            }

            return RedirectToAction("CreationAuteur", "CreationAuteur");
        }
    }
}