using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface INotificationRepository<TNotification> where TNotification : Notification
    {
        Task Delete(int id, ContextSession session);
        Task<TNotification> GetByUserId(int userId, ContextSession session, bool includeDeleted = false);
        Task<TNotification> GetByDate(DateTime date, ContextSession session, bool includeDeleted = false);
        Task<TNotification> Get(int idd, ContextSession session, bool includeDeleted = false);
        Task<TNotification> Edit(TNotification notification, ContextSession session);
    }
}
