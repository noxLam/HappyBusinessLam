using AutoMapper;
using MB.MCPP.HappyBusinessLam.Dtos.Pharmacists;
using MB.MCPP.HappyBusinessLam.Entities;

namespace MB.MCPP.HappyBusinessLam.Api.AutoMapperProfiles
{
    public class PharmacistAutoMapperProfile : Profile
    {
        public PharmacistAutoMapperProfile()
        {
            CreateMap<Pharmacist, PharmacistListDto>();
            CreateMap<PharmacistDto, Pharmacist>();
            CreateMap<Pharmacist, PharmacistDetailsDto>();
        }
    }
}
