using projet_clement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_clement.Controllers
{
    public class EditPostsController : Controller
    {
        private readonly MvcEntities db = new MvcEntities(); //permet l'acces à la base de donnée. Essaye de le supprimer pour voir

        // GET: EditPosts
        [HttpGet]//c'est la méthode qui s'executera à l'affichage de la vue EditPosts
        public ActionResult EditPosts()
        {
            var allPosts = db.articles.Where(x => x.contenu != null && x.titre != null);
            /* recupere dans la base de données articles les lignes ou la
             * colonne "contenu" et "titre" ne sont pas nulle (ou elle sont remplie)
             * en gros on récupere tous les articles finis
             * */

            var allUsers = db.Users.Where(x => x.Nom != null && x.Prenom != null);
            /*on récupère tous les auteurs qui ont un nom et un prénom de renseigné*/

            var model = new HomeModel(allPosts, allUsers);
            /*on appel la méthode HomeModel en lui donnant deux paramètres, allposts et allusers*/

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPosts(int id, articles formArticle /*nom du formulaire renvoyé par la a réutiliser dans la méthode*/)
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

            return RedirectToAction("EditPosts", "EditPosts");//retourne a la vue EditPosts situé dans le répertoire Home
        }
    }
}