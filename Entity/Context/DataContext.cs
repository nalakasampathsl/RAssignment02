using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<AircraftSighting> AircraftSighting { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
