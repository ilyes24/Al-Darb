using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class CourseTaskProfile : Profile
    {
        public CourseTaskProfile()
        {
            CreateMap<CourseTask, CourseTaskDTO>().ReverseMap();
        }
    }
}
