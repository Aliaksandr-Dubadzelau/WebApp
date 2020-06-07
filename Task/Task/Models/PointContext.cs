using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Task.Models
{
    public class PointContext : DbContext
    {

        public DbSet<Point> Points { get; set; }
        public DbSet<UserData> UserData { get; set; }

    }
}