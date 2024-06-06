﻿using Cotation.Domain.Entities;

namespace Cotation.Infrastructure.Repositories.RepositoryAddress {
    public interface IAddressRepository {

        public Task<Address> Create(Address entity);
        public Task<Address> Update(Address entity);
        public Task Delete(Address entity);
        public Task<Address> GetById(Guid id);
        public Task<Address> GetByName(string name);
        public Task<Address> GetAll();
    }
}
