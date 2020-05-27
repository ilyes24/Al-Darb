using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

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
