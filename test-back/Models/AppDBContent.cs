using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_back.Models
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
    }
}
