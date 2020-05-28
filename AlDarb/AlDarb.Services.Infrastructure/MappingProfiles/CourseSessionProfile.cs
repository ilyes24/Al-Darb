using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class CourseSessionProfile : Profile
    {
        public CourseSessionProfile()
        {
            CreateMap<CourseSession, CourseSessionDTO>().ReverseMap();
        }
    }

}
