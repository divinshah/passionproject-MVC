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
    public class ClubController : Controller
    {
        private Playerscontent db = new Playerscontent();
        // GET: Club
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Clublist()
        {
            return View(db.club.ToList());
        }

        [HttpPost]
        public ActionResult Create(string Clubname_New, string League_New)
        {
            string query = "insert into clubs (ClubName, LeagueName) values (@club, @league)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@club", Clubname_New);
            myparams[1] = new SqlParameter("@league", League_New);

            db.Database.ExecuteSqlCommand(query, myparams);
            

            return RedirectToAction("Clublist");
        }

        

        public ActionResult Delete(int id)
        {
            //delete players associated with club first
            string query = "delete from Players where club_clubID = @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));
            //delete club
            query = "delete from clubs where clubID = @id";
            db.Database.ExecuteSqlCommand(query, new SqlParameter("@id", id));




            return RedirectToAction("Clublist");
        }
    }
}