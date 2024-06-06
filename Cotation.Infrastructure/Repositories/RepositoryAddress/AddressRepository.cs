using Cotation.Domain.Entities;
using Cotation.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cotation.Infrastructure.Repositories.RepositoryAddress {
    public class AddressRepository(AppDbContext context) : IAddressRepository {
        private readonly AppDbContext _context = context;
        public async Task<Address> Create(Address entity) {
            var result = await _context.Addresses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Address entity) {
            _context.Addresses.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Address>> GetAll() {
            var result = await _context.Addresses.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Address> GetById(Guid id) {
            return await _context.Addresses
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Address> Update(Address entity) {
            var result = _context.Addresses.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
