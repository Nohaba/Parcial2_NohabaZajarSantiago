using Microsoft.EntityFrameworkCore;
using Parcial2_NohabaZajarSantiago.DAL.Entities;

namespace Parcial2_NohabaZajarSantiago.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base (options)
        {

        }
        //Control Duplicidad
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NaturalPerson>().HasIndex(c => c.Identification).IsUnique();
        }
        //Mapeo mi identidad para convertirla en una tabla
        public DbSet<NaturalPerson> NaturalPersons { get; set;}

    }
}
