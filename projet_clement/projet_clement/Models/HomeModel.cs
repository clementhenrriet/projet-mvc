using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_clement.Models
{
    public class HomeModel
    {
        public List<Users> UserList { get; set; } //creation classe Userlist typée Users
        public List<articles> ArticlesList { get; set;  }//creation classe ArticlesList typée articles
        public List<int> Naissances { get; set; } //creation classe Naissances typée int
        public List<articles> AllArticles { get; set;}
        public List<articles> ArtSsTel { get; set; }
        /* ici on crée quelque chose de vide, c'est juste un plan qu'on doit remplir ou utiliser plus
 * tard
 * */


        public HomeModel(IQueryable<Users> allUsers, IQueryable<articles> ArtSansTel, IQueryable<articles> TitreArt)

       {
            UserList = new List<Users>(allUsers);
            /*création d'une liste nommée userList, dont les données sont de type Users,
             * et qui contient les données de allUsers définies dans le homecontroller
             */
            ArtSsTel = new List<articles>(ArtSansTel);

       }


        public HomeModel(IQueryable<Users> allUsers)
        /*méthode nommée HomeModel qui accepte 1 paramétre de type iqueryable, qui contient des users
         * et qu'on appelera allusers pour la réutiliser dans la méthode
         * */
        {
            UserList = new List<Users>(allUsers);
        }



        public HomeModel(IQueryable<articles> dbArticles, IQueryable<Users> dbUsers)
        {
            AllArticles = new List<articles>(dbArticles);
            UserList = new List<Users>(dbUsers);
        }
        /*ici le bdArticles = le "allposts" du contrôller car on a envoyé "allPosts" comme premier paramètre 
 * de la méthode EditPosts du homeController, et de la meme manière, le dbusers = allusers 
 de la méthode EditPosts du homeController 

 AllArticles est donc une liste qui contient tous les articles finis
 UserList est une liste qui contient tous les auteurs ayant un nom et prenom renseigné
 */

        
    }
}