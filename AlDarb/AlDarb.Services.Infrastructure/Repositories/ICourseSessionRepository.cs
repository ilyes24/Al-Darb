using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface ICourseSessionRepository<TCourseSession> where TCourseSession : CourseSession
    {
        Task<IEnumerable<TCourseSession>> GetList(ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<TCourseSession> GetByStartDate(DateTime startDate, ContextSession session, bool includeDeleted = false);
        Task<TCourseSession> GetByEndDate(DateTime endDate, ContextSession session, bool includeDeleted = false);
        Task<TCourseSession> GetByCourseId(int courseId, ContextSession session, bool includeDeleted = false);
        Task<TCourseSession> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TCourseSession> Edit(TCourseSession user, ContextSession session);
    }
}
