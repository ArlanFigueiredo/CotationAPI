using AutoMapper;
using Cotation.Application.Utilities.User;
using Cotation.Communication.DTOS.UserDTO;
using Cotation.Communication.ModelsViews.Requests.User;
using Cotation.Communication.ModelsViews.Responses.User;
using Cotation.Domain.Entities;
using Cotation.Infrastructure.Repositories.RepositoryUser;

namespace Cotation.Application.Services.SUser {
    public class RegisterUserService(IUserRepository userRepository, IMapper mapper, GenerateHashPassword generateHashPassword) {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly GenerateHashPassword _generateHashPassword = generateHashPassword;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseUser> Execute(RequestUser entity) {
            var user = await _userRepository.GetByEmail(entity.Email);
            if (user != null) {
                throw new Exception("Usuario já existe.");
            }

            var resultHash = await _generateHashPassword.GenerateHashPasswordAsync(entity.Password);

            var newUser = MapToUser(entity);

            newUser.Password = resultHash.PasswordHasher;
            newUser.Salt = resultHash.HashSalt;

            var createUser = await _userRepository.Create(newUser);

            return new ResponseUser {
                Id = createUser.Id,
                Name = createUser.Name,
            };
        }

        public User MapToUser(RequestUser entity) {
            return _mapper.Map<DTOUser, User>(new DTOUser(entity));
        }

    }
}
