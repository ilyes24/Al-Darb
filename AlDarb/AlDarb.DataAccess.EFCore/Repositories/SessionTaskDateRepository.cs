using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class SessionTaskDateRepository : BaseDeletableRepository<SessionTaskDate, DataContext>, ISessionTaskDateRepository<SessionTaskDate>
    {
        public SessionTaskDateRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SessionTaskDate>> GetByTaskId(int taskId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.TaskId == taskId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SessionTaskDate>> GetBySessionId(int sessionId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.SessionId == sessionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SessionTaskDate>> GetList(int? sessionId, int? taskId, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (sessionId != null)
                entity = entity.Where(obj => obj.SessionId == sessionId);

            if (taskId != null)
                entity = entity.Where(obj => obj.TaskId == taskId);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
