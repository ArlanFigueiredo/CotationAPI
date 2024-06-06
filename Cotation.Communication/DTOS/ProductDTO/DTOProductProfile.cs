using AutoMapper;
using Cotation.Domain.Entities;

namespace Cotation.Communication.DTOS.ProductDTO {
    public class DTOProductProfile : Profile {
        public DTOProductProfile() {
            CreateMap<Product, DTOProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.PriceUnit, opt => opt.MapFrom(src => src.PriceUnit))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ReverseMap();
        }
    }
}
