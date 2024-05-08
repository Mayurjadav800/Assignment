using Assignment.Dto;
using Assignment.Model;
using AutoMapper;

namespace Assignment.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
