using Microsoft.EntityFrameworkCore;
using Practica_CRUD;
using Practica_CRUD.Class;

namespace Practica_CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolUser>().HasKey(sc => new { sc.UserId, sc.RolId });

            modelBuilder.Entity<RolUser>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.RolUser)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<RolUser>()
                .HasOne<Rol>(sc => sc.Rol)
                .WithMany(s => s.RolUser)
                .HasForeignKey(sc => sc.RolId);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolUser> RolUser { get; set; }

    }
}
