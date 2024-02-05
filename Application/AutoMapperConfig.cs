using AutoMapper;
using Infrastructure.Dto;

namespace Application
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
 
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonDto>()
            .ReverseMap();
        }
    }
}
