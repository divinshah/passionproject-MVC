using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Passionprojectdivy.Models
{
    public class Playerscontent : DbContext
    {
        public Playerscontent()
        {

        }
        public DbSet<Player> teamplayer { get; set; }
        public DbSet<Club> club { get; set; }
    }
}