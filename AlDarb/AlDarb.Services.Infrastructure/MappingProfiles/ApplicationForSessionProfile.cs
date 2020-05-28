using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class ApplicationForSessionProfile : Profile
    {
        public ApplicationForSessionProfile()
        {
            CreateMap<ApplicationForSession, ApplicationForSessionDTO>().ReverseMap();
        }
    }
}
