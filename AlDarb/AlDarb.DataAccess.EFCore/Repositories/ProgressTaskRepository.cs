using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class ProgressTaskRepository : BaseDeletableRepository<ProgressTask, DataContext>, IProgressTaskRepository<ProgressTask>
    {
        public ProgressTaskRepository(DataContext context) : base(context)
        {
        }

        public async Task<ProgressTask> GetByTaskId(int taskId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.CourseTask.Id == taskId)
                .FirstOrDefaultAsync();
        }

        public async Task<ProgressTask> GetByUserId(int userId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.User.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
