using AutoMapper;
using AlDarb.DTO;
using AlDarb.Entities;


namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
        }
    }
}
