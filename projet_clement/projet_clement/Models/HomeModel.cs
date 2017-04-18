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

       public HomeModel(IQueryable<Users> allUsers, List<articles> articles)
       {
            Naissances = new List<int>(allUsers.Select(x => x.Naissance.Value.Year));
            UserList = new List<Users>(allUsers);
            ArticlesList = new List<articles>(articles);

       }
    }
}