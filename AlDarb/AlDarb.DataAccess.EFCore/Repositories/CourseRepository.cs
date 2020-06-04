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
    public class CourseRepository : BaseDeletableRepository<Course, DataContext>, ICourseRepository<Course>
    {
        public CourseRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>> GetByName(string name, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.Name == name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetByUserId(int userId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.User.Id == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetList(int? userId, string name, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (userId != null)
                entity = entity.Where(obj => obj.UserId == userId);

            if (!String.IsNullOrEmpty(name))
                entity = entity.Where(obj => obj.Name == name);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
