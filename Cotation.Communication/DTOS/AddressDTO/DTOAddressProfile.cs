using AutoMapper;
using Cotation.Domain.Entities;

namespace Cotation.Communication.DTOS.AddressDTO {
    public class DTOAddressProfile : Profile {

        public DTOAddressProfile() {
            CreateMap<Address, DTOAddress>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.Road, opt => opt.MapFrom(src => src.Road))
                .ForMember(dest => dest.NeighBorHood, opt => opt.MapFrom(src => src.NeighBorHood))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ReverseMap();

                

        }
    }
}
