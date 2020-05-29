using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class NotificationRepository : BaseDeletableRepository<Notification, DataContext>, INotificationRepository<Notification>
    {
        public NotificationRepository(DataContext context) : base(context)
        {
        }

        public async Task<Notification> GetByDate(DateTime date, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.DateTime == date)
                .FirstOrDefaultAsync();
        }

        public async Task<Notification> GetByUserId(int userId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.User.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
