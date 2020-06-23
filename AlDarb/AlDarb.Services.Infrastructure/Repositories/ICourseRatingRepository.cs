using AlDarb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlDarb.Services.Infrastructure.Repositories
{
    public interface ICourseRatingRepository<TCourseRating> where TCourseRating : CourseRating
    {
        Task<IEnumerable<TCourseRating>> GetList(int? userId, int? courseId, ContextSession session, bool includeDeleted = false);
        Task Delete(int id, ContextSession session);
        Task<TCourseRating> Get(int id, ContextSession session, bool includeDeleted = false);
        Task<TCourseRating> Edit(TCourseRating courseRating, ContextSession session);
    }
}
