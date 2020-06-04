using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<ApplicationForSession>> GetList(int? userId, int? sessionId, DateTime? date, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (userId != null)
                entity = entity.Where(obj => obj.UserId == userId);

            if (sessionId != null)
                entity = entity.Where(obj => obj.CourseSessionId == sessionId);

            if (date != null)
                entity = entity.Where(obj => obj.AcceptedDate > date);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
