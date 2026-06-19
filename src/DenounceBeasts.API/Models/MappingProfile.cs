using AutoMapper;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.API.Models.Dtos.Sectors;
using DenounceBeasts.API.Models.Entities;

namespace DenounceBeasts.API.Models
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
