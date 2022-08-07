using AutoMapper;
using MB.MCPP.HappyBusinessLam.Dtos.Classifications;
using MB.MCPP.HappyBusinessLam.Entities;

namespace MB.MCPP.HappyBusinessLam.Api.AutoMapperProfiles
{
    public class ClassificationAutoMapperProfile : Profile
    {
        public ClassificationAutoMapperProfile()
        {
            CreateMap<Classification, ClassificationDto>().ReverseMap();
        }
    }
}
