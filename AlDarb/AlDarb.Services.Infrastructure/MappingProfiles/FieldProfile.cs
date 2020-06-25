using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;

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
