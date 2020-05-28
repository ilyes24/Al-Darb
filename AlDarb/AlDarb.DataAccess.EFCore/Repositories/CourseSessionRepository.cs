using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class CourseSessionRepository : BaseDeletableRepository<CourseSession, DataContext>, ICourseSessionRepository<CourseSession>
    {
        public CourseSessionRepository(DataContext context) : base(context)
        {
        }

        public  async Task<CourseSession> GetByCourseId(int courseId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.Course.Id == courseId)
                .FirstOrDefaultAsync();
        }

        public async Task<CourseSession> GetByEndDate(DateTime endDate, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.EndDate == endDate)
                .FirstOrDefaultAsync();
        }

        public async Task<CourseSession> GetByStartDate(DateTime startDate, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.StartDate == startDate)
                .FirstOrDefaultAsync();
        }
    }
}
