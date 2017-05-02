using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ead_Mini_project_3.Models
{

    //enum 
    public enum Genre
    {
        [Display(Name = "Rock")]
        Rock,
        [Display(Name = "Pop")]
        Pop,
        [Display(Name = "Punk")]
        Punk,
        [Display(Name = "Rap")]
        Rap,
        [Display(Name = "Metal")]
        Metal,
        [Display(Name = "Dance")]
        Dance
    }

    public class Band
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Band Name")]
        public string BandName { get; set; }


        public string Albums { get; set; }

        
        public Genre Genres { get; set; }

        public string Members { get; set; }


        [Display(Name = "Band Website")]

        public string BandWebsite { get; set; }



        public string Youtube { get; set; }

        [EmailAddress]
        public string Contact { get; set; }

        public override string ToString()
        {
            return "Band Name: " + BandName + " Albums: " + Albums + " Genre: " + Genres + " Members: " + Members + " Website: " + " YouTube: " + Youtube + " Contact: " + Contact;
        }


    }
}