using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface IProgressTaskRepository<TProgressTask> where TProgressTask : ProgressTask
    {
        Task Delete(int id, ContextSession session);
        Task<TProgressTask> GetByUserId(int userId, ContextSession session, bool includeDeleted = false);
        Task<TProgressTask> GetByTaskId(int taskId, ContextSession session, bool includeDeleted = false);
        Task<TProgressTask> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TProgressTask> Edit(TProgressTask progressTask, ContextSession session);
    }
}
