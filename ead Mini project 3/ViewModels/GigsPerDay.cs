using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ead_Mini_project_3.Models;

namespace ead_Mini_project_3.ViewModels
{


    public class GigsPerDay
    {

        [DataType(DataType.Text)]
        public DateTime Time { get; set; }

        public int GigCount { get; set; }
    }
}