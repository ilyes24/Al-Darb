using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class SessionTaskDateProfile : Profile
    {
        public SessionTaskDateProfile()
        {
            CreateMap<SessionTaskDate, SessionTaskDateDTO>().ReverseMap();
        }
    }
}
