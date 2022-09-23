using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocationApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
