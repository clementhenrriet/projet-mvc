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

            var ArtSanstel = db.articles.Where(x => x.userId == SansTel.userId);
            /* recupere dans la Bd articles tous les articles qui ont le meme UserId 
             * que celui qui n'a pas de telephone dans la base de donnée Users 
             * */

            var TitreArt = db.articles.Where(x => x.contenu != null);  
                
            var model = new HomeModel(allUsers, ArtSanstel, TitreArt);//on envoie trois paramètres à la 
            //méthode HomeModel, arguments qu'on a définni au dessus. On envoie pas du vide

            return View(model);

        }




        //méthodes formulaire modif users

        [HttpGet]//c'est la méthode qui s'executera à l'affichage de la vue Edituser
        public ActionResult EditUser()
        {        
            var allUsers = db.Users.Where(x => x.Nom != null);
            /* recupere dans la base de données User les id de toutes les lignes ou la
             * colonne "nom" n'est pas nulle (ou elle est remplie)
             * */
            var model = new HomeModel(allUsers);
            return View(model);
        }

        [HttpPost]//c'est la méthode qui s'executera quand on validera l'envoi de formulaire depuis le navigateur
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

            return RedirectToAction("EditUser", "Home");//retourne a la vue EditUser situé dans le répertoire Home
        }



        //méthode formulaire modif des articles

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

            return RedirectToAction("EditPosts", "Home");//retourne a la vue EditPosts situé dans le répertoire Home
        }

        



        //méthode crétion auteur

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
                RedirectToAction("CreationAuteur", "Home");
            }

            return RedirectToAction("CreationAuteur", "Home");
        }



        //méthode supression auteur

        [HttpGet]
        public ActionResult SupressionAuteur()
        {
            var allUsers = db.Users.Where(x => x.Nom != null);
            /* recupere dans la base de données User les id de toutes les lignes ou la
             * colonne "nom" n'est pas nulle (ou elle est remplie)
             * */
            var model = new HomeModel(allUsers);
            return View(model);
        }

        [HttpPost]
        public ActionResult SupressionAuteur(string Nom, string Prenom)
        {

            var userId = db.Users.Single(x => x.Nom == Nom && x.Prenom == Prenom);
            db.Users.Remove(userId);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}