using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface ICourseTaskRepository<TCourseTask> where TCourseTask : CourseTask
    {
        Task<IEnumerable<TCourseTask>> GetList(int? courseId, string title, ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<TCourseTask> GetByCourseId(int courseId, ContextSession session, bool includeDeleted = false);
        Task<TCourseTask> GetByTitle(string title, ContextSession session, bool includeDeleted = false);
        Task<TCourseTask> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TCourseTask> Edit(TCourseTask courseTask, ContextSession session);
    }
}
