using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class ApplicationForSessionRepository : BaseDeletableRepository<ApplicationForSession, DataContext>, IApplicationForSessionRepository<ApplicationForSession>
    {
        public ApplicationForSessionRepository(DataContext context) : base(context)
        {
        }

        public async Task<ApplicationForSession> GetByApplicationDate(DateTime applicationDate, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.ApplicationDate == applicationDate)
                .FirstOrDefaultAsync();
        }

        public async Task<ApplicationForSession> GetByCourseSessionId(int courseSessionId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.CourseSession.Id == courseSessionId)
                .FirstOrDefaultAsync();
        }

        public async Task<ApplicationForSession> GetByUserId(int userId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.User.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
