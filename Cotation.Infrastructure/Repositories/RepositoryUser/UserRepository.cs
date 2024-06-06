using Cotation.Domain.Entities;
using Cotation.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cotation.Infrastructure.Repositories.RepositoryUser {
    public class UserRepository(AppDbContext context) : IUserRepository {
        private readonly AppDbContext _context = context;
        public async Task<User> Create(User entity) {
            var user = await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task Delete(User entity) {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll() {
            var users = await _context.Users
                .AsNoTracking()
                .ToListAsync();
            return users;
        }

        public async Task<User> GetByEmail(string email) {
            return await _context.Users
                .AsNoTracking()
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetById(Guid id) {
            return await _context.Users
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> Update(User entity) {
            var user = _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }
    }
}
