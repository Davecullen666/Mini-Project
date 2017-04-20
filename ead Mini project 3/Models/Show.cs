using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ead_Mini_project_3.Models
{

    public class Show
    {
    public int Id { get; set; }
    [Required]
    [Display(Name = "Show Name")]
    public string ShowName { get; set; }

    [Required]
    public string Venue { get; set; }


    public DateTime Time { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    [Display(Name = "Main band ")]
    public String MainBand { get; set; }

    [Required]
    [Display(Name = "Support band ")]
    public string SupportBand { get; set; }

    [Required]
    [Display(Name = "Tickets Available ")]
    public int TicketsAvailable { get; set; }

    [Display(Name = "Sold Out ")]
    public bool SoldOut { get; set; }


    }
}