using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace EFC
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<QRCodeEntity> QRCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>()
                        .HasIndex(d => d.Name)
                        .IsUnique();

            modelBuilder.Entity<Food>()
                        .HasIndex(d => d.Name)
                        .IsUnique();

            modelBuilder.Entity<QRCodeEntity>()
                        .HasIndex(q => q.QRCodeText)
                        .IsUnique();

            modelBuilder.Entity<Drink>()
                        .Property(d => d.Price)
                        .HasPrecision(18, 2);

            modelBuilder.Entity<Food>()
                        .Property(f => f.Price)
                        .HasPrecision(18, 2);

            modelBuilder.Entity<Food>().HasQueryFilter(f => !f.IsDeleted);
            modelBuilder.Entity<Drink>().HasQueryFilter(d => !d.IsDeleted);
            modelBuilder.Entity<QRCodeEntity>().HasQueryFilter(q => !q.IsDeleted);

            //modelBuilder.Seed();
        }

    }
}
