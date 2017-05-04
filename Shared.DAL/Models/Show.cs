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
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Required]
    [Display(Name = "Main Act ")]
    public String MainBand { get; set; }

    [Display(Name = "Support Act ")]
    public string SupportBand { get; set; }

    [Required]
    [Range(0,999)]
    [Display(Name = "Tickets Available ")]
    public int TicketsAvailable { get; set; }

    [Display(Name = "Sold Out ")]
        public bool SoldOut
        {
            get
            {
                if (TicketsAvailable == 0)
                { return true; }
                else
                { return false; }
            }

        }


    }
}
