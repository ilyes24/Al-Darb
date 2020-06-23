using AlDarb.Entities;
using AlDarb.Services.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<bool> UpdateCourse(int courseId, ContextSession session)
        {
            var courseRatingEntity = GetContext(session).Set<CourseRating>().Where(obj => obj.CourseId == courseId).AsQueryable();
            var courseRatingSum = courseRatingEntity.Count();
            var courseRatingAvg = courseRatingEntity.Average(x => x.Rating);
            var courseEntity = GetContext(session).Set<Course>().Where(obj => obj.Id == courseId).FirstOrDefault();
            courseEntity.AvgRating = Convert.ToInt32(courseRatingAvg);
            courseEntity.SumRating = courseRatingSum;
            return true;
        }
    }
}
