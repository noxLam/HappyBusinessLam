using AutoMapper;
using MB.MCPP.HappyBusinessLam.Dtos.Drugs;
using MB.MCPP.HappyBusinessLam.Entities;

namespace MB.MCPP.HappyBusinessLam.Api.AutoMapperProfiles
{
    public class DrugAutoMapperProfile : Profile
    {
        public DrugAutoMapperProfile()
        {
            CreateMap<Drug, DrugListDto>();
            CreateMap<Drug, DrugDetailsDto>();
            CreateMap<DrugDto, Drug>();
        }
    }
}
