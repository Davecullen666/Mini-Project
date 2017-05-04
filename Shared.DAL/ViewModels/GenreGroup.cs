using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ead_Mini_project_3.Models;

namespace ead_Mini_project_3.ViewModels
{
    

    public class GenreGroup
        {
        
        [DataType(DataType.Text)]
            public Genre Genres { get; set; }

            public int BandCount { get; set; }
        }
    }
