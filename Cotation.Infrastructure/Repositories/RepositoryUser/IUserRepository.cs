using Cotation.Domain.Entities;

namespace Cotation.Infrastructure.Repositories.RepositoryUser {
    public interface IUserRepository {
        public Task<User> Create(User entity);
        public Task<User> Update(User entity);  
        public Task Delete(User entity);
        public Task<List<User>> GetAll();
        public Task<User> GetByEmail(string email);
        public Task<User> GetById(Guid id);
    }
}
