using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class CourseSessionRepository : BaseDeletableRepository<CourseSession, DataContext>, ICourseSessionRepository<CourseSession>
    {
        public CourseSessionRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CourseSession>> GetList(int? courseId, DateTime? startDate, DateTime? endDate, ContextSession session, bool includeDeleted = false)
        {
            var sessions = GetEntities(session, includeDeleted).AsQueryable();

            if (courseId != null)
                sessions = sessions.Where(obj => obj.CourseId == courseId);

            if (startDate != null)
                sessions = sessions.Where(obj => obj.StartDate > startDate);

            if (endDate != null)
                sessions = sessions.Where(obj => obj.EndDate < endDate);

            return await sessions.Where(obj => obj.Id > 0).ToListAsync();
        }

        public  async Task<IEnumerable<CourseSession>> GetByCourseId(int courseId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.Course.Id == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseSession>> GetByEndDate(DateTime endDate, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.EndDate == endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseSession>> GetByStartDate(DateTime startDate, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.StartDate == startDate)
                .ToListAsync();
        }

        public async Task<bool> ClearToSession(int courseId, DateTime start, DateTime end, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted);

            var z = await entity.Where(obj => obj.CourseId == courseId).ToListAsync();

            foreach (var e in z)
            {
                if ((e.StartDate < start && e.EndDate > start) || (e.StartDate < end && e.EndDate > end) || (e.StartDate > start && e.EndDate < end))
                    return false;
            }

            return true;
        }

        public async Task<int> NumberOfApplications(int sessionId, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted);
            var z = await entity.Where(obj => obj.Id == sessionId).ToListAsync<CourseSession>();

            return z.Count();
        }
    }
}
