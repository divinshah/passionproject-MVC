using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Passionprojectdivy.Models;
//including this for the extra definition
using System.Diagnostics;

namespace Passionprojectdivy.Controllers
{
    public class PlayerController : Controller
    {
        private Playerscontent db = new Playerscontent();
        // GET: Player
        public ActionResult New()
        {
            return View(db.club.ToList());

        }
        public ActionResult PlayerLisst()
        {
            return View(db.teamplayer.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player author = db.teamplayer.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }


        [HttpPost]
        public ActionResult Create(string Playername_New, string Position_New, string PlayerClub_New, string Rating_New)
        {
            //Standard query representation   
            string query = "insert into players (PlayerName, PlayerPostion, PlayerTeam, PlayerRating) values (@name, @position, @team, @rating)";
            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@name", Playername_New);
            myparams[1] = new SqlParameter("@position", Position_New);
            myparams[2] = new SqlParameter("@team", PlayerClub_New);
            myparams[3] = new SqlParameter("@rating", Rating_New);
            //forcing the blog to have an author

            //putting that information into the database by running a command
            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("PlayerLisst");
        }

        public ActionResult Delete(int id)
        {
            string query = "delete from players where playerID = @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));




            return RedirectToAction("PlayerLisst");
        }
    }
}