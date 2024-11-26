using AutoMapper;
using tourismproject.Dto;
using tourismproject.Entity;

namespace tourismproject.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }

}
