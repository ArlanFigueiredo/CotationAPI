using AutoMapper;
using Cotation.Domain.Entities;

namespace Cotation.Communication.DTOS.UserDTO {
    public class DTOUserProfile : Profile {

        public DTOUserProfile() {
            CreateMap<User, DTOUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Salt, opt => opt.MapFrom(src => src.Salt))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ReverseMap();
        }
    }
}

