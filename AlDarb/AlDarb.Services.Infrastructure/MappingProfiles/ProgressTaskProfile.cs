using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class ProgressTaskProfile : Profile
    {
        public ProgressTaskProfile()
        {
            CreateMap<ProgressTask, ProgressTaskDTO>().ReverseMap();
        }
    }
}
