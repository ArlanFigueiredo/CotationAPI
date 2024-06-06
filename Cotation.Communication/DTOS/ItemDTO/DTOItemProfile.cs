using AutoMapper;
using Cotation.Domain.Entities;

namespace Cotation.Communication.DTOS.ItemDTO {
    public class DTOItemProfile : Profile {

        public DTOItemProfile() {
            CreateMap<Item, DTOItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ReverseMap();

        }
    }
}
