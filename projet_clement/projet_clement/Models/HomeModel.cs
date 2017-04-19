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
        /* ici on crée quelque chose de vide, c'est juste un plan qu'on doit remplir ou utiliser plus
         * tard
         * */
        public List<articles> TitreArticle { get; set;}
        public List<articles> ArtSsTel { get; set; }


       public HomeModel(IQueryable<Users> allUsers, IQueryable<articles> ArtSansTel, IQueryable<articles> TitreArt)
       {
            UserList = new List<Users>(allUsers);
            ArtSsTel = new List<articles>(ArtSansTel);
            TitreArticle = new List<articles>(TitreArt);
       }

        public HomeModel(IQueryable<Users> allUsers)
        {
            UserList = new List<Users>(allUsers);
        }
    }
}