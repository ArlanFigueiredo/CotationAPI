using Cotation.Domain.Entities;
using Cotation.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cotation.Infrastructure.Repositories.RepositoryItem {
    public class ItemsRepository(AppDbContext context) : IItemsRepository {
        private readonly AppDbContext _context = context;
        public async Task<Item> Create(Item entity) {
            var item = await _context.Items.AddAsync(entity);  
            await _context.SaveChangesAsync();
            return item.Entity;
        }

        public async Task Delete(Item entity) {
            _context.Items.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAll() {
           var item = await _context.Items.AsNoTracking().ToListAsync();
            return item;
        }

        public async Task<List<Item>> GetByCompanyId(Guid companyId) {
            return await _context.Items
                .AsNoTracking()
                .Where(x => x.CompanyId == companyId).ToListAsync();

        }

        public async Task<Item> GetById(Guid id) {
            return await _context.Items
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

        }
        public async Task<Item> Update(Item entity) {
            var item = _context.Items.Update(entity);
            await _context.SaveChangesAsync();
            return item.Entity;
        }
    }
}
