using Cotation.Domain.Entities;
using Cotation.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cotation.Infrastructure.Repositories.RepositoryCompany {
    public class CompanyRepository(AppDbContext context) : ICompanyRepository {
        private readonly AppDbContext _context = context;

        public async Task<Company> Create(Company entity) {
            var company = await _context.Companies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return company.Entity;
        }

        public async Task Delete(Company entity) {
            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<List<Company>> GetAll() {
            var companies =  _context.Companies.AsNoTracking().ToListAsync();
            return companies;
        }

        public async Task<Company> GetByCompany(string name) {
            return await _context.Companies
                .AsNoTracking()
                .Where(company => company.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<Company> GetById(Guid id) {
            return await _context.Companies.AsNoTracking()
                .Where(company => company.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Company> Update(Company entity) {
            var company = _context.Companies.Update(entity);
            await _context.SaveChangesAsync();
            return company.Entity;
        }


    }
}
