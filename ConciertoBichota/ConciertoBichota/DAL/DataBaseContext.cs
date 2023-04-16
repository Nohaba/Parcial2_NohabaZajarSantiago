using ConciertoBichota.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ConciertoBichota.DAL
{
    public class DataBaseContext : DbContext 
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<ConcertDB> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ConcertDB>().HasIndex(c => c.Id).IsUnique();
        }
    }
}
