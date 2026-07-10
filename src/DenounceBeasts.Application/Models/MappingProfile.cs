using AutoMapper;
using DenounceBeasts.Application.Models.Dtos;
using DenounceBeasts.Application.Models.Dtos.Sectors;
using DenounceBeasts.Application.Models.Entities;
using DenounceBeasts.Domain.Entities;

namespace DenounceBeasts.Application.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sector, SectorDto>()
                .ForMember(dest => dest.MunicipalityName,
                opt => opt.MapFrom(src => src.Municipality != null ? src.Municipality.Name : string.Empty)); 
           
            CreateMap<SectorDto, Sector>();

            CreateMap<CreateSectorDto, Sector>();
            //CreateMap<Sector, CreateSectorDto>();

            CreateMap<Status, StatusDto>().ReverseMap();
            //CreateMap<StatusDto, Status>();

            CreateMap<ComplaintType, ComplaintTypeDto>().ReverseMap();
            //CreateMap<ComplaintTypeDto, ComplaintType>();
        }

    }
}
