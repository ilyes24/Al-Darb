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
    public class CourseFieldRepository : BaseDeletableRepository<CourseField, DataContext>, ICourseFieldRepository<CourseField>
    {
        public CourseFieldRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CourseField>> GetByCourseId(int courseId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseField>> GetList(int? courseId, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (courseId != null)
                entity = entity.Where(obj => obj.CourseId == courseId);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
