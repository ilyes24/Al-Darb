using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface IApplicationForSessionRepository<TApplicationForSession> where TApplicationForSession : ApplicationForSession
    {
        Task<IEnumerable<TApplicationForSession>> GetList(ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<TApplicationForSession> GetByApplicationDate(DateTime applicationDate, ContextSession session, bool includeDeleted = false);
        Task<TApplicationForSession> GetByUserId(int userId, ContextSession session, bool includeDeleted = false);
        Task<TApplicationForSession> GetByCourseSessionId(int courseSessionId, ContextSession session, bool includeDeleted = false);
        Task<TApplicationForSession> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TApplicationForSession> Edit(TApplicationForSession applicationForSession, ContextSession session);
    }
}
