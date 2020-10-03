using AlDarb.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface ICourseFieldRepository<TCourseField> where TCourseField : CourseField
    {
        Task<IEnumerable<TCourseField>> GetList(int? courseId, ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<IEnumerable<TCourseField>> GetByCourseId(int courseId, ContextSession session, bool includeDeleted = false);
        Task<TCourseField> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TCourseField> Edit(TCourseField course, ContextSession session);
    }
}
