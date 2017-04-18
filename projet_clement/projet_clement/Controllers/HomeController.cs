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
            /* recupere dans la base de données User les id de toutes les lignes ou la
             * colonne nom n'est pas nulle (ou elle est remplie)
             * */

            var ArtSanstel = db.articles.Where(x => x.userId == SansTel.userId).ToList();
            /* recupere dans la Bd articles tous les articles qui ont le meme UserId 
             * que celui qui n'a pas de telephone dans la base de donnée Users 
             * et on en fait une liste
             * */


            var model = new HomeModel(allUsers, ArtSanstel);

            return View(model);
        }
    }
}