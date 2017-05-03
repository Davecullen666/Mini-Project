using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ead_Mini_project_3.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("SomeNewDB2")
        {

        }

        public DbSet<Band> bands { get; set; }
        public DbSet<Show> shows { get; set; }

    }
}