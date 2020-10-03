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
    public class DonationPostRepository : BaseDeletableRepository<DonationPost, DataContext>, IDonationPostRepository<DonationPost>
    {
        public DonationPostRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DonationPost>> GetByUserId(int userId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.User.Id == userId)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<DonationPost>> GetByFieldId(int fieldId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.FieldId == fieldId)
                .ToListAsync();
        }

        public async Task<IEnumerable<DonationPost>> GetList(int? userId, int? fieldId, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (userId != null)
                entity = entity.Where(obj => obj.UserId == userId);

            if (fieldId != null)
                entity = entity.Where(obj => obj.FieldId == fieldId);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
