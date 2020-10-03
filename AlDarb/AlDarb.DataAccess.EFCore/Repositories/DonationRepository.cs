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
    public class DonationRepository : BaseDeletableRepository<Donation, DataContext>, IDonationRepository<Donation>
    {
        public DonationRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Donation>> GetByPostId(int? postId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.DonationPostId == postId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Donation>> GetByUserId(int userId, ContextSession session, bool includeDeleted = false)
        {
            return await GetEntities(session, includeDeleted)
                .Where(obj => obj.User.Id == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Donation>> GetList(int? userId, int? postId, ContextSession session, bool includeDeleted = false)
        {
            var entity = GetEntities(session, includeDeleted).AsQueryable();

            if (userId != null)
                entity = entity.Where(obj => obj.UserId == userId);

            if (postId != null)
                entity = entity.Where(obj => obj.DonationPostId == postId);

            return await entity.Where(obj => obj.Id > 0).ToListAsync();
        }
    }
}
