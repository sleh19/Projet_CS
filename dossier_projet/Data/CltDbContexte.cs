using Microsoft.EntityFrameworkCore;
using projet.Models;
namespace projet.Data
{
    public class CltDbContexte : DbContext
    {
        public CltDbContexte() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=Projet;Trusted_Connection=True;");
        }
        public DbSet<Client> clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("clients");
        }
    }
}
