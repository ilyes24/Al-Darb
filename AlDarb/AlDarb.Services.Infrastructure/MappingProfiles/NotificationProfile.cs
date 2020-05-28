using AlDarb.DTO;
using AlDarb.Entities;
using AutoMapper;

namespace AlDarb.Services.Infrastructure.MappingProfiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDTO>().ReverseMap();
        }
    }
}
