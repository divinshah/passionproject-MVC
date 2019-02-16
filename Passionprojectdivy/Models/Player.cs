using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Passionprojectdivy.Models
{
    public class Player
    {
        [Key]
        public int playerID { get; set; }

        //palyer name
        [Required, StringLength(255), Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        [Required, StringLength(255), Display(Name ="Position")]
        public string PlayerPostion { get; set; }

        [Required, StringLength(255), Display(Name = "Team Name")]
        public string PlayerTeam { get; set; }

        [Required, StringLength(255), Display(Name ="overall rating")]
        public string PlayerRating { get; set; }

        public virtual Club club { get; set; }

    }
}