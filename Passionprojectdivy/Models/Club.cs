using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Passionprojectdivy.Models
{
    public class Club
    {
        [Key]
        public int clubID { get; set; }

        [Required, StringLength(255), Display(Name = "Club Name")]
        public string ClubName { get; set; }

        [Required, StringLength(255), Display(Name = "League Name")]
        public string LeagueName { get; set; }



        public virtual ICollection<Player> player { get; set; }

    }
}