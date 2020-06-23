using AutoMapper;
using AlDarb.DTO;
using AlDarb.Entities;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class CourseRatingProfile : Profile
    {
        public CourseRatingProfile()
        {
            CreateMap<CourseRating, CourseRatingDTO>().ReverseMap();
        }
    }
}
