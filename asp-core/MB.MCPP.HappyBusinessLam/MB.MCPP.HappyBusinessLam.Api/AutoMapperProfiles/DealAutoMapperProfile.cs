using AutoMapper;
using MB.MCPP.HappyBusinessLam.Dtos.Deals;
using MB.MCPP.HappyBusinessLam.Entities;

namespace MB.MCPP.HappyBusinessLam.Api.AutoMapperProfiles
{
    public class DealAutoMapperProfile : Profile
    {
        public DealAutoMapperProfile()
        {
            CreateMap<Deal, DealListDto>();
            CreateMap<Deal, DealDetailsDto>();
            CreateMap<DealDto, Deal>();
        }
    }
}
