using projet_clement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_clement.Controllers
{
    public class HomeController : Controller
    {
        private readonly MvcEntities db = new MvcEntities();
        // GET: Home


        public ActionResult Index()
        {
            var SansTel = db.Users.Where(x => x.Numero == null).FirstOrDefault(); 
            /* recupere dans la base de donnée Users la ligne id de celui qui n'a pas 
             * de numero de telephone. la recherche s'arrete à la premiere ligne 
             * trouvée sans numero de telephone            
             * */
            var allUsers = db.Users.Where(x => x.Nom != null);
            /* recupere dans la base de données User toutes les lignes ou la
             * colonne nom n'est pas nulle (ou elle est remplie)
             * */

            var TousLesArticles = db.articles.Where(x => x.titre != null);

            var ArtSanstel = db.articles.Where(x => x.userId == SansTel.userId);
            /* recupere dans la Bd articles tous les articles qui ont le meme UserId 
             * que celui qui n'a pas de telephone dans la base de donnée Users 
             * */

            var TitreArt = db.articles.Where(x => x.contenu != null);  
                
            var model = new HomeModel(TousLesArticles, allUsers);//on envoie trois paramètres à la 
            //méthode HomeModel, arguments qu'on a définni au dessus. On envoie pas du vide

            return View(model);

        }

        //méthodes formulaire modif users

        //[HttpGet]//c'est la méthode qui s'executera à l'affichage de la vue Edituser
        //public ActionResult EditUser()
        //{
            
        //    var allUsers = db.Users.Where(x => x.Nom != null);
        //    /* recupere dans la base de données User les id de toutes les lignes ou la
        //     * colonne "nom" n'est pas nulle (ou elle est remplie)
        //     * */
        //    var model = new HomeModel(allUsers);
        //    return View(model);
        //}

        //[HttpPost]//c'est la méthode qui s'executera quand on validera l'envoi de formulaire depuis le navigateur
        //public ActionResult EditUser(int id, Users formUser /*nom du formulaire a réutiliser plus bas*/)
        //{
        //    //user dans la bdd
        //    var dbUser = db.Users.FirstOrDefault(x => x.userId == id);

        //    dbUser.Nom = formUser.Nom;
        //    dbUser.Prenom = formUser.Prenom;
        //    dbUser.Naissance = formUser.Naissance;
        //    dbUser.Numero = formUser.Numero;
        //    dbUser.Departement = formUser.Departement;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch(Exception e)
        //    {
        //        return View(e);
        //    }

        //    return RedirectToAction("Index", "Home");//retourne a la vue EditUser situé dans le répertoire Home
        //}

        public ActionResult EditUser (int userId)
        {
            var Nom= db.Users.Where(x => x.userId == userId).Select(x => x.Nom);
            


            return View();
        }

    }
}