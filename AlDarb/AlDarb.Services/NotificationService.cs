using AlDarb.DTO;
using AlDarb.Entities;
using AlDarb.Services.Infrastructure;
using AlDarb.Services.Infrastructure.Repositories;
using AlDarb.Services.Infrastructure.Services;
using AlDarb.Utils;
using System;
using System.Threading.Tasks;

namespace AlDarb.Services
{
    public class NotificationService<TNotification> : BaseService, INotificationService where TNotification : Notification, new()
    {
        protected readonly INotificationRepository<TNotification> notificationRepository;
        public NotificationService(ICurrentContextProvider contextProvider, INotificationRepository<TNotification> notificationRepository) : base(contextProvider)
        {
            this.notificationRepository = notificationRepository;
        }

        public async Task<bool> Delete(int id)
        {
            await notificationRepository.Delete(id, Session);
            return true;
        }

        public async Task<NotificationDTO> Edit(NotificationDTO dto)
        {
            var notification = dto.MapTo<TNotification>();
            await notificationRepository.Edit(notification, Session);
            return notification.MapTo<NotificationDTO>();
        }

        public async Task<NotificationDTO> GetByDate(DateTime date, bool includeDeleted = false)
        {
            var notification = await notificationRepository.GetByDate(date, Session, includeDeleted);
            return notification.MapTo<NotificationDTO>();
        }

        public async Task<NotificationDTO> GetById(int id, bool includeDeleted = false)
        {
            var notification = await notificationRepository.Get(id, Session, includeDeleted);
            return notification.MapTo<NotificationDTO>();
        }

        public async Task<NotificationDTO> GetByUserId(int userId, bool includeDeleted = false)
        {
            var notification = await notificationRepository.GetByUserId(userId, Session, includeDeleted);
            return notification.MapTo<NotificationDTO>();
        }
    }
}
