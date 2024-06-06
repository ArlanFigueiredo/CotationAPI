using Cotation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cotation.Infrastructure.Context {
    public class AppDbContext : DbContext {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options) {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Company>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Company)
                .HasForeignKey<Address>(a => a.CompanyId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Items)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Item>()
               .HasOne(i => i.Company)
               .WithMany(c => c.Items)
               .HasForeignKey(i => i.CompanyId);

            modelBuilder.Entity<Cotations>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Cotations)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<Cotations>()
                 .HasOne(c => c.User)
                 .WithMany(u => u.Cotations)
                 .HasForeignKey(c => c.UserId);
        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cotations> Cotations { get; set; }
    }
}
