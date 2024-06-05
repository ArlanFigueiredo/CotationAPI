using Cotation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cotation.Infrastructure.Context {
    public class AppDbContext(IConfiguration configuration) : DbContext {
        private readonly IConfiguration _configuration = configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {


            modelBuilder.Entity<Company>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Company)
                .HasForeignKey<Company>(a => a.AddressId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Company)
                .WithOne(c => c.Address)
                .HasForeignKey<Address>(a => a.CompanyId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Items)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Cotations>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Cotations)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Company)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CompanyId);
        }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Item> Items { get; set; }
        public DbSet<Cotations> Cotations { get; }
    }

}

