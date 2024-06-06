using AutoMapper;
using Cotation.Domain.Entities;

namespace Cotation.Communication.DTOS.CotationsDTO {
    public class DTOCotationsProfile : Profile {

        public DTOCotationsProfile() {

            CreateMap<Cotations, DTOCotations>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ReverseMap();
        }
    }
}
