using Microsoft.EntityFrameworkCore;
using projet.Models;
namespace projet.Data
{
    public class ProdDbContexte : DbContext
    {
        public ProdDbContexte() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=Projet;Trusted_Connection=True;");
        }
        public DbSet<Produit> prods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>().ToTable("Prod");
        } 
    }
}
