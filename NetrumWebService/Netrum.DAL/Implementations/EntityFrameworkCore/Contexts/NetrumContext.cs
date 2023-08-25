using Microsoft.EntityFrameworkCore;
using Netrum.Model.Entities;


namespace Netrum.DAL.Implementations.EntityFrameworkCore.Contexts
{

    public class NetrumContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey("Nickname");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog = Netrum;User ID=SA;Password=reallyStrongPwd123;TrustServerCertificate = true");
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Person>? Persons { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
