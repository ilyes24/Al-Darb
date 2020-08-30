using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface ISessionTaskDateRepository<TSessionTaskDate> where TSessionTaskDate : SessionTaskDate
    {
        Task<IEnumerable<TSessionTaskDate>> GetList(int? sessionId, int? taskId, ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<TSessionTaskDate>> GetByTaskId(int taskId, ContextSession session, bool includeDeleted = false);
        Task<IEnumerable<TSessionTaskDate>> GetBySessionId(int sessionId, ContextSession session, bool includeDeleted = false);
        Task<TSessionTaskDate> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TSessionTaskDate> Edit(TSessionTaskDate sessionTaskDate, ContextSession session);
    }
}
