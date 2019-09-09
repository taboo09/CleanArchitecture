using AutoMapper;
using Clean.Data.Dtos;
using Clean.Data.Entities;

namespace Clean.Infrastructure.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Domain to API Resources
            CreateMap<Homes, HomeDto>();
            CreateMap<Staffs, StaffDto>();
            CreateMap<Qualifications, QualDto>();

            // API Resouces to Domain
            CreateMap<HomeDto, Homes>();
            CreateMap<StaffDto, Staffs>();
            CreateMap<QualDto, Qualifications>();
            CreateMap<StaffToUpdateDto, Staffs>();
        }
    }
}