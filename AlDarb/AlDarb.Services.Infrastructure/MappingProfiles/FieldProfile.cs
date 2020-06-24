using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class FieldProfile : Profile
    {
        public FieldProfile()
        {
            CreateMap<Field, FieldDTO>().ReverseMap();
        }
    }
}
