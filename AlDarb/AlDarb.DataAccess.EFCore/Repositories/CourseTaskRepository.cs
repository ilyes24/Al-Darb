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
    public class CourseTaskRepository : BaseDeletableRepository<CourseTask, DataContext>, ICourseTaskRepository<CourseTask>
    {
        public CourseTaskRepository(DataContext context) : base(context)
        {
        }

        public async Task<CourseTask> GetByCourseId(int courseId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.Course.Id == courseId)
                .FirstOrDefaultAsync();
        }

        public async Task<CourseTask> GetByTitle(string title, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.Title == title)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CourseTask>> GetList(int? courseId, string title, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (courseId != null)
                entity = entity.Where(obj => obj.CourseId == courseId);

            if(String.IsNullOrEmpty(title))
                entity = entity.Where(obj => obj.Title == title);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
