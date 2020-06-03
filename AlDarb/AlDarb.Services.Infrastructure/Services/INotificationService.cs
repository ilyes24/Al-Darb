using AlDarb.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDTO>> GetList(bool includeDeleted = false);
        Task<NotificationDTO> GetById(int id, bool includeDeleted = false);
        Task<NotificationDTO> GetByDate(DateTime date, bool includeDeleted = false);
        Task<NotificationDTO> GetByUserId(int userId, bool includeDeleted = false);
        Task<bool> Delete(int id);
        Task<NotificationDTO> Edit(NotificationDTO dto);
    }
}
