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

        public int UserArticleAModifier;

        public ActionResult Index()
        {
            var SansTel = db.Users.Where(x => x.Numero == null).FirstOrDefault(); 
            /* recupere dans la base de donnée Users la ligne id de celui qui n'a pas 
             * de numero de telephone. la recherche s'arrete à la premiere ligne 
             * trouvée sans numero de telephone            
             * */
            var allUsers = db.Users.Where(x => x.Nom != null);
            /* recupere dans la base de données User les id de toutes les lignes ou la
             * colonne nom n'est pas nulle (ou elle est remplie)
             * */

            var ArtSanstel = db.articles.Where(x => x.userId == SansTel.userId);
            /* recupere dans la Bd articles tous les articles qui ont le meme UserId 
             * que celui qui n'a pas de telephone dans la base de donnée Users 
             * */

            var TitreArt = db.articles.Where(x => x.contenu != null);
            

            var model = new HomeModel(allUsers, ArtSanstel, TitreArt);

            return View(model);

        }




        //méthodes formulaire modif users

        [HttpGet]
        public ActionResult EditUser()
        {
          
            var allUsers = db.Users.Where(x => x.Nom != null);
            /* recupere dans la base de données User les id de toutes les lignes ou la
             * colonne nom n'est pas nulle (ou elle est remplie)
             * */
            var model = new HomeModel(allUsers);

            return View(model);

        }

        [HttpPost]
        public ActionResult EditUser(int id, Users formUser /*nom du formulaire a réutiliser plus bas*/)
        {
            //user dans la bdd
            var dbUser = db.Users.FirstOrDefault(x => x.userId == id);

            dbUser.Nom = formUser.Nom;
            dbUser.Prenom = formUser.Prenom;
            dbUser.Naissance = formUser.Naissance;
            dbUser.Numero = formUser.Numero;
            dbUser.Departement = formUser.Departement;

            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {
                return View(e);
            }

            return RedirectToAction("EditUser", "Home");
        }


        [HttpGet]
        public ActionResult EditPosts()
        {

            var allPosts = db.articles.Where(x => x.contenu != null && x.titre != null);
            /* recupere dans la base de données User les id de toutes les lignes ou la
             * colonne nom n'est pas nulle (ou elle est remplie)
             * */

            var allUsers = db.Users.Where(x => x.Nom != null && x.Prenom != null);
            var model = new HomeModel(allPosts, allUsers);

            return View(model);

        }

        [HttpPost]
        public ActionResult EditPosts(int id, articles formArticle /*nom du formulaire a réutiliser plus bas*/)
        {
            //user dans la bdd
            var dbUser = db.Users.FirstOrDefault(x => x.userId == id);

            var dbArticle = db.articles.FirstOrDefault(x => x.id == id);

            dbArticle.titre = formArticle.titre;
            dbArticle.contenu = formArticle.contenu;
            dbArticle.userId = formArticle.userId;

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return View(e);
            }

            return RedirectToAction("EditPosts", "Home");
        }

    }
}