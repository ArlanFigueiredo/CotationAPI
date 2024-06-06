using Cotation.Domain.Entities;
using Cotation.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cotation.Infrastructure.Repositories.RepositoryCotations {
    public class CotationsRepository(AppDbContext context) : ICotationRepository {
        private readonly AppDbContext _context = context;
        public async Task<Cotations> Create(Cotations entity) {
            var cotation = await _context.Cotations.AddAsync(entity);   
            await _context.SaveChangesAsync();
            return cotation.Entity;
        }

        public async Task Delete(Cotations entity) {
            _context.Cotations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cotations>> GetAll() {
            var cotations = await _context.Cotations
                .AsNoTracking()
                .ToListAsync();
            return cotations;
        }

        public async Task<Cotations> GetById(Guid id) {
            return await _context.Cotations
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        }

        public async Task<Cotations> Update(Cotations entity) {
            var cotations = _context.Cotations.Update(entity);
            await _context.SaveChangesAsync();
            return cotations.Entity;
        }
    }
}
