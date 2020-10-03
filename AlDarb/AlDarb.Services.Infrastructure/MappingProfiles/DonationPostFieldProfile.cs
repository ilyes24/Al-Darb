using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class DonationPostFieldProfile : Profile
    {
        public DonationPostFieldProfile()
        {
            CreateMap<DonationPostField, DonationPostFieldDTO>().ReverseMap();
        }
    }
}
