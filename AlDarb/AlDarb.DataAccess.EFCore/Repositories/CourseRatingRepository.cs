using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlDarb.DataAccess.EFCore.Repositories
{
    public class CourseRatingRepository : BaseDeletableRepository<CourseRating, DataContext>, ICourseRatingRepository<CourseRating>
    {
        public CourseRatingRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CourseRating>> GetList(int? userId, int? courseId, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (userId != null)
                entity = entity.Where(obj => obj.UserId == userId);

            if (courseId != null)
                entity = entity.Where(obj => obj.CourseId == courseId);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
