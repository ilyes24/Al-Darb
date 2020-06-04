using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface ICourseSessionRepository<TCourseSession> where TCourseSession : CourseSession
    {
        Task<IEnumerable<TCourseSession>> GetList(int? courseId, DateTime? startDate, DateTime? endDate, ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<TCourseSession>> GetByStartDate(DateTime startDate, ContextSession session, bool includeDeleted = false);
        Task<IEnumerable<TCourseSession>> GetByEndDate(DateTime endDate, ContextSession session, bool includeDeleted = false);
        Task<IEnumerable<TCourseSession>> GetByCourseId(int courseId, ContextSession session, bool includeDeleted = false);
        Task<TCourseSession> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TCourseSession> Edit(TCourseSession user, ContextSession session);
    }
}
