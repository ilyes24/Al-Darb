using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class DonationPostProfile : Profile
    {
        public DonationPostProfile()
        {
            CreateMap<DonationPost, DonationPostDTO>().ReverseMap();
        }
    }
}
