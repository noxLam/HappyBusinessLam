using AutoMapper;
using MB.MCPP.HappyBusinessLam.Dtos.Buyers;
using MB.MCPP.HappyBusinessLam.Entities;

namespace MB.MCPP.HappyBusinessLam.Api.AutoMapperProfiles
{
    public class BuyerAutoMapperProfile : Profile
    {
        public BuyerAutoMapperProfile()
        {
            CreateMap<Buyer, BuyerListDto>();
            CreateMap<Buyer, BuyerDetailsDto>();
            CreateMap<BuyerDto, Buyer>();
        }
    }
}
