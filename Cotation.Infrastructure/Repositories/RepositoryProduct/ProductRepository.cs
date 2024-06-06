using Cotation.Domain.Entities;
using Cotation.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cotation.Infrastructure.Repositories.RepositoryProduct {
    public class ProductRepository(AppDbContext context) : IProductRepository {
        private readonly AppDbContext _context = context;

        public async Task<Product> Create(Product entity) {
            var produtct = await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return produtct.Entity;
        }

        public async Task Delete(Product entity) {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll() {
            var items = await _context.Products
                .AsNoTracking()
                .ToListAsync();
            return items;
        }

        public async Task<Product> GetById(Guid id) {
            return await _context.Products
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
                    
        }

        public async Task<Product> GetByName(string name) {
            return await _context.Products
                .AsNoTracking()
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<Product> Update(Product entity) {
            var item = _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return item.Entity;
        }
    }
}
